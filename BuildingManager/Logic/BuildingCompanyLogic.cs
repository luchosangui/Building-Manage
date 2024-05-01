using APIModels.InputModels;
using APIModels.OutputModels;
using Domain;
using IData;
using ILogic;

namespace Logic
{
    public class BuildingCompanyLogic: IBuildingCompanyLogic
    {
        private readonly IGenericRepository<BuildingCompany> _repository;
        public BuildingCompanyLogic(IGenericRepository<BuildingCompany> repository)
        {
            _repository = repository;
        }

        public BuildingCompanyResponse CreateBuildingCompany(BuildingCompanyRequest buildingCompanyRequest)
        {

            var dataBuildComp = _repository.Insert(buildingCompanyRequest.ToEntity());
            return new BuildingCompanyResponse(dataBuildComp);
        }


        public BuildingCompanyResponse GetBuildingById(int id)
        {
            BuildingCompany buildingCompany = _repository.Get(x => x.Id == id);

            if (buildingCompany == null)
            {
                throw new KeyNotFoundException($"No buildingCompany found with ID {id}");
            }

            return new BuildingCompanyResponse(buildingCompany);
        }
    }
}


