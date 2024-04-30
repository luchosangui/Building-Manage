using APIModels.InputModels;
using APIModels.OutputModels;
using Domain;
using IData;
using ILogic;

namespace Logic
{
    public class CategoryServiceLogic: ICategoryServiceLogic 
    {
        private readonly IGenericRepository<CategoryService> _repository;

        public CategoryServiceLogic(IGenericRepository<CategoryService> repository) {
            _repository = repository;
        }
        
        

        public CategoryServiceResponse CreateCategoryService(CategoryServiceRequest categoryServiceRequest) {

            var dataCatServ = _repository.Insert(categoryServiceRequest.ToEntity());
            return new CategoryServiceResponse(dataCatServ);
        }

    }
}

