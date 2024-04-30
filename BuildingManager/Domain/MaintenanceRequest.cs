using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{

    public enum StateMaintenance
    {
        abierto,
        cerrado,
        atendido
        

    }

    public class MaintenanceRequest
    {
        
        public int Id { get; set; }
        public Apartment Apartment { get; set; }
        public string Description { get; set; }
        public CategoryService CategoryService { get; set; }

        public StateMaintenance state { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

         public MaintenanceRequest() { }


        public MaintenanceRequest(Apartment apartment, string description, CategoryService categoryService, int id, StateMaintenance state)
        {
            Id = id;
            Apartment = apartment;
            Description = description;
            CategoryService = categoryService;
            this.state = state;
            
        }
    }
}