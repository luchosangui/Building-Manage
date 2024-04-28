using Domain;
using Microsoft.EntityFrameworkCore;
using System;


namespace Data
{
    public class MaintenenceRequestManagement : GenericRepository<MaintenanceRequest>
    {
        public MaintenenceRequestManagement(DbContext context)
        {
            Context = context;
        }
    }
}