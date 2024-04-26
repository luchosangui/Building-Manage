using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data
{
    public class BuildingManagerContext : DbContext
    {
        public BuildingManagerContext(DbContextOptions<BuildingManagerContext> options) : base(options) {
           // Console.WriteLine("SHOLD RUN MIGRATIONS");
            this.Database.Migrate();
        }
        //agregar relations tables
        public DbSet<User>? Users { get; set; }
        public DbSet<Building>? Buildings { get; set; }
        public DbSet<Apartment>? Apartments { get; set; }
        public DbSet<BuildingCompany>? BuildingCompanies { get; set; }
        public DbSet<MaintenanceRequest>? MaintenanceRequests { get; set; }

        public DbSet<Invitation>? Invitation { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
             IConfigurationRoot configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
                

                var connectionString = configuration.GetConnectionString("BuildingManagerDB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
