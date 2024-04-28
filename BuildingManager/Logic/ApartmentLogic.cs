using APIModels.InputModels;
using APIModels.OutputModels;
using Domain;
using IData;
using ILogic;


namespace Logic
{
    public class ApartmentLogic: IApartmentLogic
    {
        private readonly IGenericRepository<Apartment> _repository;
        public ApartmentLogic(IGenericRepository<Apartment> repository)
        {
            _repository = repository;
        }

        public ApartmentResponse CreateApartment(ApartmentRequest apartmentRequest)
        {

            var dataApt = _repository.Insert(apartmentRequest.ToEntity());
            return new ApartmentResponse(dataApt);
        }

    }
}

