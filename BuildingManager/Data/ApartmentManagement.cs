using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApartmentManagement : GenericRepository<Invitation>
    {
        public ApartmentManagement(DbContext context)
        {
            Context = context;
        }
    }
}