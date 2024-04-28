using APIModels.InputModels;
using ILogic;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManager.Controllers
{
    [Route("api/apartment")]
    public class ApartmentController: Controller
    {

        private readonly IApartmentLogic _apartmentLogic;
        public ApartmentController(IApartmentLogic logic)
        {
            _apartmentLogic = logic;

        }

        [HttpPost]
        public IActionResult CreateApartment([FromBody] ApartmentRequest received)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newInvitation = _apartmentLogic.CreateApartment(received.ToApartmentRequest());
            return CreatedAtAction(nameof(CreateApartment), new { id = newInvitation.Id }, newInvitation);
        }

    }
}

