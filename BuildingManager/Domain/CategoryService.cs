using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CategoryService
    {
        
        public int Id { get; set; }
        public string Name { get;  set; }

        public CategoryService() { }

        public CategoryService(string name, int id) {
            int Id= id;
            Name = name;
        }
    }
}
