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
        public BuildingLogic(IGenericRepository<Building> repository)
        {
            _repository = repository;
        }

        public BuildingResponse CreateBuilding(BuildingRequest buildingRequest) {

            var dataBuild = _repository.Insert(buildingRequest.ToEntity());
            return new BuildingResponse(dataBuild);
        }


    }
}

