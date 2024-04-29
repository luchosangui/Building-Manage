using Microsoft.AspNetCore.Mvc;
using APIModels.InputModels;
using ILogic;
using Logic;

namespace BuildingManager.Controllers
{
    [Route("api/buildings")]
    public class BuildingController: Controller
    {

        private readonly IBuildingLogic _buildingLogic;
        private readonly IBuildingCompanyLogic _buildingCompanyLogic;
        public BuildingController(IBuildingLogic logic, IBuildingCompanyLogic buildingCompanyLogic)
        {
            _buildingLogic = logic;
            _buildingCompanyLogic = buildingCompanyLogic;

        }

        [HttpPost]
        public IActionResult CreateBuilding([FromBody] BuildingRequest received)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newBuilding = _buildingLogic.CreateBuilding(received.ToBuildingRequest());
                return CreatedAtAction(nameof(CreateBuilding), new { id = newBuilding.Id }, newBuilding);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { error = ex.Message });
            }


        }

    }
}


