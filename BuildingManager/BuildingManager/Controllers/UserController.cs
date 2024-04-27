using Microsoft.AspNetCore.Mvc;
//using BuildingManager.Filters; para cuando agregue los filters
using APIModels.InputModels;
using ILogic;

namespace BuildingManager.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserLogic _userLogic;
        public UserController(IUserLogic logic)
        {
            _userLogic = logic;
            
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest received) {

            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }

            var newUser = _userLogic.CreateUser(received.ToUserRequest());
            return CreatedAtAction(nameof(CreateUser), new { id = newUser.Id }, newUser);
        }

     

       
    }
}
