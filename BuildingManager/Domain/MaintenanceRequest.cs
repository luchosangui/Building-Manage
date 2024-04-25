using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{

  
    public class MaintenanceRequest
    {
        
        public int Id { get; set; }
        public Apartment Apartment { get; set; }
        public string Description { get; set; }
        public CategoryService CategoryService { get; set; }

        //estado

         public MaintenanceRequest() { }


        public MaintenanceRequest(Apartment apartment, string description, CategoryService categoryService, int id)
        {
            Id = id;
            Apartment = apartment;
            Description = description;
            CategoryService = categoryService;
        }
    }
}