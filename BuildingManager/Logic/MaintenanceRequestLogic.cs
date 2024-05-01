using APIModels.InputModels;
using APIModels.OutputModels;
using Domain;
using IData;
using ILogic;
using System.Linq;


namespace Logic
{
    public class MaintenanceRequestLogic : IMaintenanceRequestLogic
    {
        private readonly IGenericRepository<MaintenanceRequest> _repository;

        public MaintenanceRequestLogic(IGenericRepository<MaintenanceRequest> repository)
        {
            _repository = repository;
        }

        public MaintenenceRequestResponse CreateMaintenenceRequest(MaintenanceRequestRequest maintenanceRequestRequest)
        {

            var dataMaintReq = _repository.Insert(maintenanceRequestRequest.ToEntity());
            return new MaintenenceRequestResponse(dataMaintReq);
        }

        public MaintenenceRequestResponse GetMaintenanceRequestById(int id)
        {
            MaintenanceRequest maintenenceRequest = _repository.Get(x => x.Id == id);
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



        //revisar
        public IEnumerable<MaintenenceRequestResponse> GetAllUsers()
        {
            var maintenanceRequest = _repository.GetAll<MaintenanceRequest>();
            var listMaintenanceRequest = maintenanceRequest.Select(maintenanceRequest => new MaintenenceRequestResponse(maintenanceRequest));
            return listMaintenanceRequest;
        }

        public MaintenenceRequestResponse UpdateMaintenanceRequest(int id, MaintenanceRequestRequest updatedMaintenanceRequest)
        {
            // && !"".Equals(updatedMaintenanceRequest.Name.Trim())

            MaintenanceRequest maintenanceRequest = _repository.Get(x => x.Id == id);



            if (updatedMaintenanceRequest.Apartment != null)
            {
                maintenanceRequest.Apartment = updatedMaintenanceRequest.Apartment;
            }

            if (updatedMaintenanceRequest.Description != null && !"".Equals(updatedMaintenanceRequest.Description.Trim()))
            {
                maintenanceRequest.Description = updatedMaintenanceRequest.Description;
            }

            if (updatedMaintenanceRequest.CategoryService != null)
            {
                maintenanceRequest.CategoryService = updatedMaintenanceRequest.CategoryService;
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



