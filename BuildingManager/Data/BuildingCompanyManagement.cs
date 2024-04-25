
using Microsoft.EntityFrameworkCore;
using Domain;


namespace Data
{
    public class BuildingCompanyManagement : GenericRepository<User>
    {
        public BuildingCompanyManagement(DbContext context)
        {
            Context = context;
        }
    }
}