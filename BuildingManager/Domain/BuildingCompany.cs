using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BuildingCompany
    {
        [Key]
        public int Id { get;  set; }
        public string Name { get; set; }

        public BuildingCompany() { }

        public BuildingCompany(string name, int id)
        {
            Id = id;
            Name = name;
        }
    }
}