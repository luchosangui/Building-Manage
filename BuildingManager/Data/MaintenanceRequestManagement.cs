


using Microsoft.EntityFrameworkCore;
using Domain;


namespace Data
{
    public class MaintenanceRequestManagement : GenericRepository<User>
    {
        public MaintenanceRequestManagement(DbContext context)
        {
            Context = context;
        }
    }
}

