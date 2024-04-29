using APIModels.InputModels;
using ILogic;
using Logic;
using Microsoft.AspNetCore.Mvc;


namespace BuildingManager.Controllers
{
    [Route("api/buildingCompany")]
    public class BuildingCompanyController:Controller
    {

        private readonly IBuildingCompanyLogic _buildingCompanyLogic;
        public BuildingCompanyController(IBuildingCompanyLogic logic)
        {
            _buildingCompanyLogic = logic;

        }

        [HttpPost]

        public IActionResult CreateBuildingCompany([FromBody] BuildingCompanyRequest recieved) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var newBuildingCompany = _buildingCompanyLogic.CreateBuildingCompany(recieved.ToBuildingCompanyRequest());
            return CreatedAtAction(nameof(CreateBuildingCompany), new { id = newBuildingCompany.Id }, newBuildingCompany);
        }

    }
}




