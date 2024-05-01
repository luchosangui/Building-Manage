using APIModels.InputModels;
using APIModels.OutputModels;
using Domain;
using IData;
using ILogic;

namespace Logic
{
    public class BuildingLogic: IBuildingLogic
    {
        private readonly IGenericRepository<Building> _repository;
        private readonly IGenericRepository<BuildingCompany> _buildingCompanyRepository;
        public BuildingLogic(IGenericRepository<Building> repository, IGenericRepository<BuildingCompany> buildingCompanyRepository)
        {
            _repository = repository;
            _buildingCompanyRepository = buildingCompanyRepository;
        }

        public BuildingResponse CreateBuilding(BuildingRequest buildingRequest) {

            BuildingCompany buildingCompany = _buildingCompanyRepository.Get(x=>x.Id==buildingRequest.BuildingCompanyId);
            
            if (buildingCompany == null)
            {
                throw new KeyNotFoundException($"No Building Company found with ID {buildingRequest.BuildingCompanyId}");
            }

            Building building = new Building(buildingRequest.Name,buildingRequest.Direction,buildingCompany, buildingRequest.Id);
            var dataBuild = _repository.Insert(building);
            return new BuildingResponse(dataBuild);
        }

        public BuildingResponse GetBuildingById(int id)
        {
            Building building = _repository.Get(x => x.Id == id);

            if (building == null)
            {
                throw new KeyNotFoundException($"No building found with ID {id}");
            }

            return new BuildingResponse(building);
        }

        public void DeleteBuildign(int id)
        {
            Building building = _repository.Get(x => x.Id == id);
            if (building != null)
            {
                _repository.Delete(building);
            }
            else
            {
                throw new ArgumentException("No Building Found with ID" + id);
            }

        }

        public BuildingResponse UpdateBuilding(int id,BuildingRequest updatedBuilding)
        {
            //conseguir de la base de datos el usuario

            Building building = _repository.Get(x => x.Id == id);

            if (updatedBuilding.Name != null && !"".Equals(updatedBuilding.Name.Trim()))
            {
                building.Name = updatedBuilding.Name;
            }

            if (updatedBuilding.Direction != null && !"".Equals(updatedBuilding.Direction.Trim()))
            {
                building.Direction = updatedBuilding.Direction;
            }

            if (updatedBuilding.BuildingCompanyId != null )
            {
                building.BuildingCompany = _buildingCompanyRepository.Get(x => x.Id == updatedBuilding.BuildingCompanyId);
            }




            var dataBuilding = _repository.Update(building);
            return new BuildingResponse(dataBuilding);


        }




    }
}

