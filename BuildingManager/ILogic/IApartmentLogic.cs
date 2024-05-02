using APIModels.InputModels;
using APIModels.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogic
{
    public interface IApartmentLogic
    {
        public ApartmentResponse CreateApartment(ApartmentRequest apartmentRequest);
        public ApartmentResponse GetApartmentgById(int id);
        public void DeleteApartment(int id);



    }
}
