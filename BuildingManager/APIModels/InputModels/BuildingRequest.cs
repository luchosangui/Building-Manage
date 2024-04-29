using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace APIModels.InputModels
{
    public class BuildingRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Direction { get; set; }
        public int BuildingCompanyId { get; set; }
        //public List<Apartment> Apartments { get; set; }
        //public List<User> MaintenancePersons { get; set; }


        public BuildingRequest(int id, string name, string direction,int buildingCompanyId) { 
        
            Id = id;
            Name = name;
            Direction = direction;
            BuildingCompanyId = buildingCompanyId;
            //Apartments = new List<Apartment>();
            //MaintenancePersons = new List<User>();
        }

        public BuildingRequest ToBuildingRequest() {
            return new BuildingRequest(
                Id,
                Name,
                Direction,
                BuildingCompanyId


                ); }

        //public Building ToEntity() {
        //    return new Building(
        //        Name,
        //        Direction,
        //        BuildingCompany,
        //        Id
        //        );
        //}
    }
}

