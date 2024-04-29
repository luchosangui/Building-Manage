using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels.InputModels
{
    public class CategoryServiceRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        

        public CategoryServiceRequest(string name, int id)
        {
            int Id = id;
            Name = name;
        }



        public CategoryServiceRequest ToCategoryServiceRequest() {


            return new CategoryServiceRequest(
                Name,
                Id
                );

        }

        public CategoryService ToEntity() {
            return new CategoryService(
                Name,
                Id
                );
        }

    }
}

