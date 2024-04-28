using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels.OutputModels
{
    public class ApartmentResponse
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public User Owner { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public bool HasTerrace { get; set; }

        public ApartmentResponse(Apartment apartment)
        {

            Id = apartment.Id;
            Floor = apartment.Floor;
            Number = apartment.Number;
            Owner = apartment.Owner;
            NumberOfBedrooms = apartment.NumberOfBedrooms;
            NumberOfBathrooms = apartment.NumberOfBathrooms;
            HasTerrace = apartment.HasTerrace;

        }


    }
}
