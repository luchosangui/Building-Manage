using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels.InputModels
{
    public class ApartmentRequest
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public User Owner { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public bool HasTerrace { get; set; }

        public ApartmentRequest(int id, int floor, int number, User owner, int numberOfBedrooms, int numberOfBathrooms, bool hasTerrace) {

            Id = id;
            Floor = floor;
            Number = number;
            Owner = owner;
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            HasTerrace = hasTerrace;

        }

        public ApartmentRequest ToApartmentRequest(){

            return new ApartmentRequest( 

                Id,
                Floor,
                Number,
                Owner,
                NumberOfBedrooms,
                NumberOfBathrooms,
                HasTerrace


            );
        }

        public Apartment ToEntity() {
            return new Apartment(
                Id,
                Floor,
                Owner,
                Number,
                NumberOfBedrooms,
                HasTerrace,
                NumberOfBathrooms



                );
        }

    }
}

