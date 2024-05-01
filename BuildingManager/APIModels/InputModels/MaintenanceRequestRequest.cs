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

        public StateMaintenance StateMaintenance { get; set; }

        //public DateTime DateStart { get; set; }
        //public DateTime DateEnd { get; set; }

       


        public MaintenanceRequestRequest(Apartment apartment, string description, CategoryService categoryService, int id, StateMaintenance stateMaintenance)
        {
            Id = id;
            Apartment = apartment;
            Description = description;
            CategoryService = categoryService;
            StateMaintenance = stateMaintenance;
        }

        public MaintenanceRequestRequest ToMaintenanceRequestRequest() {


            return new MaintenanceRequestRequest(
                Apartment,
                Description,
                CategoryService,
                Id,
                StateMaintenance
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

