using APIModels.InputModels;
using APIModels.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogic
{
    public interface IMaintenanceRequestLogic
    {
        public MaintenenceRequestResponse CreateMaintenenceRequest(MaintenanceRequestRequest maintenanceRequestRequest);
        public MaintenenceRequestResponse GetMaintenanceRequestById(int id);
        public void DeleteMaintenenceRequest(int id);
        public IEnumerable<MaintenenceRequestResponse> GetAllUMaintenanceRequest();
        public MaintenenceRequestResponse UpdateMaintenanceRequest(int id, MaintenanceRequestRequest updatedMaintenanceRequest);

        public IEnumerable<GroupedRequestResponse> GetMaintenanceReportBuildings();
        public IEnumerable<GroupedRequestResponse> GetMaintenanceReportByPersonID(int id);
    }
}
