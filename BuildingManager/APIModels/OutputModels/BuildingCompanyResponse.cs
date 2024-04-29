using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels.OutputModels
{
    public class BuildingCompanyResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BuildingCompanyResponse(BuildingCompany buildingCompany) {
            Name = buildingCompany.Name;
            Id = buildingCompany.Id;
        }
    }
}
