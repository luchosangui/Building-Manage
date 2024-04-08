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
        [Key]
        public Guid Id { get; set; }
        public Apartment Apartment { get; set; }
        public string Description { get; set; }
        public CategoryService CategoryService { get; set; }

        // public MaintenanceRequest() { Id = Guid.NewGuid(); }

        public MaintenanceRequest(Apartment apartment, string description, CategoryService categoryService)
        {
            Id = Guid.NewGuid();
            Apartment = apartment;
            Description = description;
            CategoryService = categoryService;
        }
    }
}