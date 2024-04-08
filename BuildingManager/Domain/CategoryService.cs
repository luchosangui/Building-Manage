using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CategoryService
    {
        public Guid IdCategoryService { get; private set; }
        public string Name { get; private set; }

        public CategoryService(string name) {
            Guid IdCategoryService = Guid.NewGuid();
            Name = name;
        }
    }
}
