using APIModels.InputModels;
using APIModels.OutputModels;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogic
{
    public interface IBuildingLogic
    {
        public BuildingResponse CreateBuilding(BuildingRequest buildingRequest);

        public BuildingResponse GetBuildingById(int id);
        public BuildingResponse UpdateBuilding(int id, BuildingRequest updatedBuilding);

        public void DeleteBuilding(int id);
    }
}
