using APIModels.InputModels;
using APIModels.OutputModels;
using Domain;
using IData;
using ILogic;



namespace Logic
{
    public class ApartmentLogic: IApartmentLogic
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Apartment> _repository;
        public ApartmentLogic(IGenericRepository<Apartment> repository, IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
            _repository = repository;
        }
        



        public ApartmentResponse CreateApartment(ApartmentRequest apartmentRequest)
        {
            User owner = _userRepository.Get(x=>x.Id==apartmentRequest.OwnerId);

            if (owner == null)
            {
                throw new KeyNotFoundException($"No user found with ID {apartmentRequest.OwnerId}");
            }

            Apartment apartment = new Apartment(apartmentRequest.Floor,apartmentRequest.Number,owner,apartmentRequest.NumberOfBedrooms,apartmentRequest.NumberOfBathrooms,apartmentRequest.HasTerrace,apartmentRequest.Id);
            var dataApt = _repository.Insert(apartment);
            return new ApartmentResponse(dataApt);
        }

        public ApartmentResponse GetApartmentgById(int id)
        {
            Apartment apartment = _repository.Get(x => x.Id == id);

            if (apartment == null)
            {
                throw new KeyNotFoundException($"No Apartment found with ID {id}");
            }

            return new ApartmentResponse(apartment);
        }

        public void DeleteApartment(int id)
        {
            Apartment apartment = _repository.Get(x => x.Id == id);
            if (apartment != null)
            {
                _repository.Delete(apartment);
            }
            else
            {
                throw new ArgumentException("No Apartment Found with ID" + id);
            }

        }

    }
}

