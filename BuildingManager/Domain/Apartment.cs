using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public class Apartment
    {
        public Guid Id { get; private set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public User Owner { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public bool HasTerrace { get; set; }

        public Apartment(int floor, int number, User owner, int numberOfBedrooms, int numberOfBathrooms, bool hasTerrace)
        {
            Id = Guid.NewGuid();
            Floor = floor;
            Number = number;
            Owner = owner;
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            HasTerrace = hasTerrace;
        }
    }
}