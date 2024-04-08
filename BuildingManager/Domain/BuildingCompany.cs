using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BuildingCompany
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }

        public BuildingCompany(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}