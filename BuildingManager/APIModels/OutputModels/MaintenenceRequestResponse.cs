using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace APIModels.OutputModels
{
    public class MaintenenceRequestResponse
    {
        public int Id { get; set; }
        public Apartment Apartment { get; set; }
        public string Description { get; set; }
        public CategoryService CategoryService { get; set; }



        public MaintenenceRequestResponse(MaintenanceRequest maintenenceRequest)
        {
            Id = maintenenceRequest.Id;
            Apartment = maintenenceRequest.Apartment;
            Description = maintenenceRequest.Description;
            CategoryService = maintenenceRequest.CategoryService;
        }
    }
}
