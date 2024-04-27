using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IData;
using Data;
using Domain;
using Logic;
using ILogic;



namespace ServicesFactory
{
    public class ServicesFactory
    {
        public ServicesFactory () {}

        public void ConfigureServices(IServiceCollection serviceCollection) {

            serviceCollection.AddDbContext<DbContext, BuildingManagerContext>();
            serviceCollection.AddScoped<IGenericRepository<User>, UserManagement>();
            serviceCollection.AddScoped<IGenericRepository<Invitation>, InvitationManagement>();
          

            serviceCollection.AddScoped<IUserLogic, UserLogic>();
            
            serviceCollection.AddScoped<IInvitationLogic, InvitationLogic>();
            
        }

    }
}
