using Domain;
using Microsoft.EntityFrameworkCore;
using System;


namespace Data
{
    public class BuildingManagement : GenericRepository<Building>
    {
        public BuildingManagement(DbContext context)
        {
            Context = context;
        }
    }
}