
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class InvitationManagement : GenericRepository<Invitation>
    {
        public InvitationManagement(DbContext context)
        {
            Context = context;
        }
    }
}