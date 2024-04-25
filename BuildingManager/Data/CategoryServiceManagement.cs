

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CategoryServiceManagement : GenericRepository<Session>
    {
        public CategoryServiceManagement(DbContext context)
        {
            Context = context;
        }
    }
}
