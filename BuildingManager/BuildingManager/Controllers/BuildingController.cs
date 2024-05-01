using Microsoft.AspNetCore.Mvc;
using APIModels.InputModels;
using ILogic;
using Logic;

namespace BuildingManager.Controllers
{
    [Route("api/buildings")]
    public class BuildingController : Controller
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

        [HttpGet("{id}")]
        public IActionResult GetBuilding([FromRoute] int id)
        {

            try
            {
                var result = _buildingLogic.GetBuildingById(id);
                return Ok(result);
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }



        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBuilding([FromRoute] int id)
        {

            _buildingLogic.DeleteBuilding(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBuilding([FromRoute] int id, [FromBody] BuildingRequest buildingRequest)
        {

            var result = _buildingLogic.UpdateBuilding(id,buildingRequest);
            return Ok(result);
        }



    }
}


