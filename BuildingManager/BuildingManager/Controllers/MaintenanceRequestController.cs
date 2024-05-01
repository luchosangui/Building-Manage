using Microsoft.AspNetCore.Mvc;
using APIModels.InputModels;
using ILogic;
using Logic;

namespace BuildingManager.Controllers
{
    [Route("api/maintenanceRequest")]
    public class MaintenanceRequest : Controller
    {

        private readonly IMaintenanceRequestLogic _maintenanceRequestLogic;
        public MaintenanceRequest(IMaintenanceRequestLogic logic)
        {
            _maintenanceRequestLogic = logic;

        }

        [HttpPost]
        public IActionResult CreateMaintenanceRequest([FromBody] MaintenanceRequestRequest received)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newMaintenanceRequest = _maintenanceRequestLogic.CreateMaintenenceRequest(received.ToMaintenanceRequestRequest());
            return CreatedAtAction(nameof(CreateMaintenanceRequest), new { id = newMaintenanceRequest.Id }, newMaintenanceRequest);
        }
        [HttpGet]
        public IActionResult GetAllMaintenanceRequest()
        {

            var listMaintenanceRequest = _maintenanceRequestLogic.GetAllUMaintenanceRequest();
            return Ok(listMaintenanceRequest);

        }

        [HttpGet("{id}")]
        public IActionResult GetMaintenanceRequest([FromRoute]int id)
        {

            var result = _maintenanceRequestLogic.GetMaintenanceRequestById(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMaintenanceRequest([FromRoute]int id, [FromBody] MaintenanceRequestRequest maintenanceRequestRequest) {

            var updated = _maintenanceRequestLogic.UpdateMaintenanceRequest(id, maintenanceRequestRequest);
            return Ok(updated);
        }



    }
}