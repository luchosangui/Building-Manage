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

        private readonly IGenericRepository<Building> _buildingRepository;
        public ApartmentLogic(IGenericRepository<Apartment> repository, IGenericRepository<User> userRepository, IGenericRepository<Building>  buildingRepository)
        {
            _userRepository = userRepository;
            _repository = repository;
            _buildingRepository = buildingRepository;
        }
        



        public ApartmentResponse CreateApartment(ApartmentRequest apartmentRequest)
        {
            User owner = _userRepository.Get(x=>x.Id==apartmentRequest.OwnerId);
            Building building = _buildingRepository.Get(x=>x.Id== apartmentRequest.BuildingId);

            if (building == null)
            {
                throw new KeyNotFoundException($"No Building found with ID {apartmentRequest.BuildingId}");
            }

            if (owner == null)
            {
                throw new KeyNotFoundException($"No User found with ID {apartmentRequest.OwnerId}");
            }

            Apartment apartment = new Apartment(apartmentRequest.Floor,apartmentRequest.Number,owner,apartmentRequest.NumberOfBedrooms,apartmentRequest.NumberOfBathrooms,apartmentRequest.HasTerrace,apartmentRequest.Id,building);
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

