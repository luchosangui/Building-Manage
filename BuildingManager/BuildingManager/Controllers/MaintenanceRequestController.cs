using Microsoft.AspNetCore.Mvc;
using APIModels.InputModels;
using ILogic;
using Logic;
using Exceptions.LogicExceptions;

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
            try
            {
                var newMaintenanceRequest = _maintenanceRequestLogic.CreateMaintenenceRequest(received.ToMaintenanceRequestRequest());
                return CreatedAtAction(nameof(CreateMaintenanceRequest), new { id = newMaintenanceRequest.Id }, newMaintenanceRequest);

            }
            catch(KeyNotFoundException ex) { 
                return BadRequest(new { error = ex.Message });
            }   
            catch(WrongRoleExceptionMaintenance ex) {
                return BadRequest(new {error= ex.Message});


            }
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

            try
            {
                var updated = _maintenanceRequestLogic.UpdateMaintenanceRequest(id, maintenanceRequestRequest);
                return Ok(updated);

            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (WrongRoleExceptionMaintenance ex)
            {
                return BadRequest(new { error = ex.Message });


            }

            
        }



    }
}