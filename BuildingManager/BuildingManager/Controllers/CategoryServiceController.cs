using Microsoft.AspNetCore.Mvc;
//using BuildingManager.Filters; para cuando agregue los filters
using APIModels.InputModels;
using ILogic;
using Logic;
using Domain;

namespace BuildingManager.Controllers
{
    [Route("api/categoryService")]
    public class CategoryServiceController : Controller
    {
        private readonly ICategoryServiceLogic _categoryServiceLogic;
        public CategoryServiceController(ICategoryServiceLogic logic)
        {
            _categoryServiceLogic = logic;

        }
        [HttpPost]
        public IActionResult CreateCategoryService([FromBody] CategoryServiceRequest received)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCategoryService = _categoryServiceLogic.CreateCategoryService(received.ToCategoryServiceRequest());
            return CreatedAtAction(nameof(CreateCategoryService), new { id = newCategoryService.Id }, newCategoryService);
        }




    }
}