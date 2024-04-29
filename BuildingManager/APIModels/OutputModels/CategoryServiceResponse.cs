using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace APIModels.OutputModels
{
    public class CategoryServiceResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }



        public CategoryServiceResponse(CategoryService categoryService)
        {
            int Id = categoryService.Id;
            Name = categoryService.Name;
        }
    }

}
