using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public class Apartment
    {
        public int Id { get;  set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public User Owner { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public bool HasTerrace { get; set; }

        public Apartment() { 
        }

        public Apartment(int floor, int number, User owner, int numberOfBedrooms, int numberOfBathrooms, bool hasTerrace, int id)
        {
            Id = id;
            Floor = floor;
            Number = number;
            Owner = owner;
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            HasTerrace = hasTerrace;
        }
    }
}