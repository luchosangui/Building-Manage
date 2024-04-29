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


    }
}

