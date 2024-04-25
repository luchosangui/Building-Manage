using Microsoft.EntityFrameworkCore;
using Domain;


namespace Data
{
    public class ApartmentManagement : GenericRepository<User>
    {
        public ApartmentManagement(DbContext context)
        {
            Context = context;
        }
    }
}