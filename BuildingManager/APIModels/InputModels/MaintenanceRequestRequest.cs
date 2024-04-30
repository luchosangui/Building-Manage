using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels.InputModels
{
    public class MaintenanceRequestRequest
    {
        public int Id { get; set; }
        public Apartment Apartment { get; set; }
        public string Description { get; set; }
        public CategoryService CategoryService { get; set; }

       


        public MaintenanceRequestRequest(Apartment apartment, string description, CategoryService categoryService, int id)
        {
            Id = id;
            Apartment = apartment;
            Description = description;
            CategoryService = categoryService;
        }

        public MaintenanceRequestRequest ToMaintenanceRequestRequest() {


            return new MaintenanceRequestRequest(
                Apartment,
                Description,
                CategoryService,
                Id
                );
        }

        public MaintenanceRequest ToEntity() {

            return new MaintenanceRequest(
                Apartment,
                Description,
                CategoryService,
                Id,
                (StateMaintenance)1
                );


        }
    }
}

