using Microsoft.AspNetCore.Mvc;
using APIModels.InputModels;
using ILogic;
using APIModels.OutputModels;


namespace BuildingManager.Controllers
{
    [Route("api/maintenanceReport")]
    public class MaintenanceReportController : Controller
    {
        private readonly IMaintenanceRequestLogic _maintenanceRequestLogic;
        public MaintenanceReportController(IMaintenanceRequestLogic logic)
        {
            _maintenanceRequestLogic = logic;

        }


        [HttpGet]
        public IActionResult GetMaintenanceReportBuilding()
        {
           
            var maintenanceReportList = _maintenanceRequestLogic.GetMaintenanceReportBuildings();
            return Ok(maintenanceReportList);
            
           
        }


        [HttpGet ("{id}")]
        public IActionResult GetMaintenanceReportByMaintenancePerson([FromRoute]int id)
        {
            try
            {
                var maintenanceReportList = _maintenanceRequestLogic.GetMaintenanceReportByPersonID(id);
                return Ok(maintenanceReportList);
            }
            catch(KeyNotFoundException ex) { 
                return BadRequest(new { error= ex.Message});
            
            }
        }


    }
}