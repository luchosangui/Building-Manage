using APIModels.InputModels;
using APIModels.OutputModels;
using Domain;
using IData;
using ILogic;


namespace Logic
{
    public class MaintenanceRequestLogic: IMaintenanceRequestLogic
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
    }
}



