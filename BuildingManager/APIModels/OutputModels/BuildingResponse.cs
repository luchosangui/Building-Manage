using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels.OutputModels
{
    public class BuildingResponse
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Direction { get; set; }
        public BuildingCompany BuildingCompany { get; set; }
        public List<Apartment> Apartments { get; set; }
        public List<User> MaintenancePersons { get; set; }


        public BuildingResponse(Building building) { 
        
            Id = building.Id;
            Name = building.Name;
            Direction = building.Direction;
            BuildingCompany = building.BuildingCompany;
            Apartments = new List<Apartment>(building.Apartments);
            MaintenancePersons = new List<User>(building.MaintenancePersons);
        }
    }
}
