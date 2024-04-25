using Microsoft.EntityFrameworkCore;
using Domain;


namespace Data
{
    public class BuildingManagement : GenericRepository<User>
    {
        public BuildingManagement(DbContext context)
        {
            Context = context;
        }
    }
}