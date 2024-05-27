using APIModels.InputModels;
using APIModels.OutputModels;
using Domain;
using IData;
using ILogic;
using Exceptions;
using System.Linq;
using Exceptions.LogicExceptions;
using Microsoft.EntityFrameworkCore;


namespace Logic
{
    public class MaintenanceRequestLogic : IMaintenanceRequestLogic
    {
        private readonly IGenericRepository<MaintenanceRequest> _repository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<CategoryService> _categoryServiceRepository;
        private readonly IGenericRepository<Apartment> _apartmentRepository;

        public MaintenanceRequestLogic(IGenericRepository<MaintenanceRequest> repository, IGenericRepository<User> userRepository, IGenericRepository<CategoryService> categoryServiceRepository, IGenericRepository<Apartment> apartmentRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _categoryServiceRepository = categoryServiceRepository;
            _apartmentRepository = apartmentRepository;
        }

        public MaintenenceRequestResponse CreateMaintenenceRequest(MaintenanceRequestRequest maintenanceRequestRequest)
        {
            //terminar para category service y apartment
            User maintenancePerson = _userRepository.Get(x=>x.Id==maintenanceRequestRequest.MaintenancePersonId);
            CategoryService categoryService = _categoryServiceRepository.Get(x=>x.Id==maintenanceRequestRequest.CategoryServiceId);
            Apartment apartment = _apartmentRepository.Get(x=>x.Id== maintenanceRequestRequest.ApartmentId);

            if (maintenancePerson == null)
            {

                throw new KeyNotFoundException($"No User found with ID {maintenanceRequestRequest.MaintenancePersonId}");
            }

            if (maintenancePerson.Role != (UserRole)2)
            {

                throw new WrongRoleExceptionMaintenance($"The user needs to be a maintenance person");
            }

            if (categoryService == null)
            {

                throw new KeyNotFoundException($"No category Service  found with ID {maintenanceRequestRequest.CategoryServiceId}");
            }

            if (apartment == null)
            {

                throw new KeyNotFoundException($"No apartment found with ID {maintenanceRequestRequest.ApartmentId}");
            }


              

            MaintenanceRequest maintenance = new MaintenanceRequest(apartment, maintenanceRequestRequest.Description,categoryService,maintenanceRequestRequest.Id,maintenanceRequestRequest.StateMaintenance,maintenancePerson);
            var dataMaintReq = _repository.Insert(maintenance);
            return new MaintenenceRequestResponse(dataMaintReq);
        }

        public MaintenenceRequestResponse GetMaintenanceRequestById(int id)
        {
            var includes = new List<string> { "CategoryService", "Apartment" };
           

            MaintenanceRequest maintenenceRequest = _repository.Get(x => x.Id == id, includes);
            return new MaintenenceRequestResponse(maintenenceRequest);
        }

        public void DeleteMaintenenceRequest(int id)
        {
            MaintenanceRequest maintenanceRequest = _repository.Get(x => x.Id == id);
            if (maintenanceRequest != null)
            {
                _repository.Delete(maintenanceRequest);
            }
            else
            {
                throw new ArgumentException("No User Found with ID" + id);
            }

        }


        public IEnumerable<GroupedRequestResponse> GetMaintenanceReportBuildings()
        {
            //agarra la maintenance request con los apartment building
            var maintenanceRequests = _repository.GetAll<MaintenanceRequest>(
                x => true,
                new List<string> { "Apartment.Building" }
            );


            var groupedResults = maintenanceRequests
                .GroupBy(mr => new { mr.Apartment.Building.Id, mr.Apartment.Building.Name })
                .Select(g => new GroupedRequestResponse
                {
                    Name = g.Key.Name,
                    OpenedRequests = g.Count(mr => mr.State == StateMaintenance.abierto),
                    AttendingRequests = g.Count(mr => mr.State == StateMaintenance.atendido),
                    ClosedRequests = g.Count(mr => mr.State == StateMaintenance.cerrado)
                }).ToList();


            return groupedResults;
        }

        public IEnumerable<GroupedRequestResponse> GetMaintenanceReportByPersonID(int id) {

            var maintenanceRequests = _repository.GetAll<MaintenanceRequest>(
                   mr => mr.Apartment.Building.Id == id,
                   new List<string> { "Apartment.Building", "MaintenancePerson" }
               );

            if (maintenanceRequests == null)
            {
                throw new KeyNotFoundException($"No Maintenance person found with ID {id}");
            }

            var groupedResults = maintenanceRequests
                .GroupBy(mr => new { mr.MaintenancePerson.Id, mr.MaintenancePerson.Name })
                .Select(g => new GroupedRequestResponse
                {
                    Name = g.Key.Name,
                    OpenedRequests = g.Count(mr => mr.State == StateMaintenance.abierto),
                    AttendingRequests = g.Count(mr => mr.State == StateMaintenance.atendido),
                    ClosedRequests = g.Count(mr => mr.State == StateMaintenance.cerrado)
                }).ToList();

            return groupedResults;

        }

        //revisar
        public IEnumerable<MaintenenceRequestResponse> GetAllUMaintenanceRequest()
        {
            var includes = new List<string> { "CategoryService", "Apartment" };
            var maintenanceRequest = _repository.GetAll<MaintenanceRequest>(x => true, includes);

            var listMaintenanceRequest = maintenanceRequest.Select(maintenanceRequest => new MaintenenceRequestResponse(maintenanceRequest));
            return listMaintenanceRequest;
        }

        public MaintenenceRequestResponse UpdateMaintenanceRequest(int id, MaintenanceRequestRequest updatedMaintenanceRequest)
        {

            User maintenancePerson = _userRepository.Get(x => x.Id == updatedMaintenanceRequest.MaintenancePersonId);
            CategoryService categoryService = _categoryServiceRepository.Get(x => x.Id == updatedMaintenanceRequest.CategoryServiceId);
            Apartment apartment = _apartmentRepository.Get(x => x.Id == updatedMaintenanceRequest.ApartmentId);
            MaintenanceRequest maintenanceRequest = _repository.Get(x => x.Id == id);




            if (apartment != null)
            {
                maintenanceRequest.Apartment = _apartmentRepository.Get(x => x.Id == updatedMaintenanceRequest.ApartmentId);
            }
            

            if (updatedMaintenanceRequest.Description != null && !"".Equals(updatedMaintenanceRequest.Description.Trim()))
            {
                maintenanceRequest.Description = updatedMaintenanceRequest.Description;
            }

             if (maintenancePerson != null)
             {
                if (maintenancePerson.Role != (UserRole)2)
                {

                    throw new WrongRoleExceptionMaintenance($"The user needs to be a maintenance person");
                }

                maintenanceRequest.MaintenancePerson = _userRepository.Get(x => x.Id == updatedMaintenanceRequest.MaintenancePersonId);
             }

           
            


            if (categoryService != null)
            {
                maintenanceRequest.CategoryService = _categoryServiceRepository.Get(x=> x.Id== updatedMaintenanceRequest.CategoryServiceId);
            }

            if (updatedMaintenanceRequest.StateMaintenance == (StateMaintenance)1)
            {
                maintenanceRequest.State = updatedMaintenanceRequest.StateMaintenance;
            }

            if (updatedMaintenanceRequest.StateMaintenance == (StateMaintenance)2)
            {
                maintenanceRequest.State = updatedMaintenanceRequest.StateMaintenance;
                maintenanceRequest.DateEnd = DateTime.Now;
            }

            if (updatedMaintenanceRequest.StateMaintenance == (StateMaintenance)3)
            {
                maintenanceRequest.State = updatedMaintenanceRequest.StateMaintenance;
                maintenanceRequest.DateStart = DateTime.Now;
            }


            var dataMaintenanceRequest = _repository.Update(maintenanceRequest);
            return new MaintenenceRequestResponse(dataMaintenanceRequest);
        }
    }
}



