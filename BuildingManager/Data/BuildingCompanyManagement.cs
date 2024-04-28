

using Domain;
using Microsoft.EntityFrameworkCore;
using System;


namespace Data
{
    public class BuildingCompanyManagement : GenericRepository<BuildingCompany>
    {
        public BuildingCompanyManagement(DbContext context)
        {
            Context = context;
        }
    }
}