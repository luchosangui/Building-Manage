using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{


    public class Building
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Direction { get; set; }
        public BuildingCompany BuildingCompany { get; set; }
        public List<Apartment> Apartments { get; set; }
        public List<User> MaintenancePersons { get; set; }

        public Building(string name, string direction, BuildingCompany buildingCompany)
        {
            Id = Guid.NewGuid();
            Name = name;
            Direction = direction;
            BuildingCompany = buildingCompany;
            Apartments = new List<Apartment>();
            MaintenancePersons = new List<User>();
        }
    }
}