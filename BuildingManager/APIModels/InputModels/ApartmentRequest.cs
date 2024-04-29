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
        public int OwnerId { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public bool HasTerrace { get; set; }

        public ApartmentRequest(int id, int floor, int number, int ownerId, int numberOfBedrooms, int numberOfBathrooms, bool hasTerrace) {

            Id = id;
            Floor = floor;
            Number = number;
            OwnerId = ownerId;
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            HasTerrace = hasTerrace;

        }

        public ApartmentRequest ToApartmentRequest(){

            return new ApartmentRequest( 

                Id,
                Floor,
                Number,
                OwnerId,
                NumberOfBedrooms,
                NumberOfBathrooms,
                HasTerrace


            );
        }

        //public Apartment ToEntity() {
        //    return new Apartment(
        //        Id,
        //        Floor,
        //        Owner,
        //        Number,
        //        NumberOfBedrooms,
        //        HasTerrace,
        //        NumberOfBathrooms



        //        );
        //}

    }
}

