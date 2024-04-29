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
        private readonly IUserLogic _userLogic;
        public ApartmentController(IApartmentLogic logic,IUserLogic userLogic)
        {
            _apartmentLogic = logic;
            _userLogic = userLogic;

        }

        [HttpPost]
        public IActionResult CreateApartment([FromBody] ApartmentRequest received)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newApartment = _apartmentLogic.CreateApartment(received.ToApartmentRequest());
                return CreatedAtAction(nameof(CreateApartment), new { id = newApartment.Id }, newApartment);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { error = ex.Message });
            }

           
        }

    }
}

