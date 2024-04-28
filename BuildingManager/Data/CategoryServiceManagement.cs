using Domain;
using Microsoft.EntityFrameworkCore;
using System;


namespace Data
{
   public class CategoryServiceManagement : GenericRepository<CategoryService>
    {
        public CategoryServiceManagement(DbContext context)
        {
            Context = context;
        }
    }
}