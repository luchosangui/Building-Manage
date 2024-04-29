using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels.InputModels
{
    public class BuildingCompanyRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BuildingCompanyRequest(int id, string name)
        {

            Id = id;
            Name = name;
        }

        public BuildingCompanyRequest ToBuildingCompanyRequest()
        {
            return new BuildingCompanyRequest(
                Id,
                Name
            );


        }

        public BuildingCompany ToEntity() { 
            return new BuildingCompany(
                Name,
                Id
                );
        
        }
    }

}

