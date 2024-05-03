using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{


    public class Building
    {
        
        public int Id { get;  set; }
        public string Name { get; set; }
        public string Direction { get; set; }
        public BuildingCompany BuildingCompany { get; set; }
        public List<Apartment> Apartments { get; set; }
        public List<User> MaintenancePersons { get; set; }

        public Building() { }

        public Building(string name, string direction, BuildingCompany buildingCompany, int id)
        {
            Id = id;
            Name = name;
            Direction = direction;
            BuildingCompany = buildingCompany;

        }
    }
}