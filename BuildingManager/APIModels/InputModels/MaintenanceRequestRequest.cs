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
        public int ApartmentId { get; set; }
        public string Description { get; set; }
        public int CategoryServiceId { get; set; }

        public StateMaintenance StateMaintenance { get; set; }

        public int MaintenancePersonId { get; set; }

        

        public MaintenanceRequestRequest(int apartmentId, string description, int categoryServiceId, int id, StateMaintenance stateMaintenance, int maintenancePersonId)
        {
            Id = id;
            ApartmentId = apartmentId;
            Description = description;
            CategoryServiceId = categoryServiceId;
            StateMaintenance = stateMaintenance;
            MaintenancePersonId = maintenancePersonId;
        }

        public MaintenanceRequestRequest ToMaintenanceRequestRequest() {


            return new MaintenanceRequestRequest(
                ApartmentId,
                Description,
                CategoryServiceId,
                Id,
                StateMaintenance,
                MaintenancePersonId
                );
        }

       
    }
}

