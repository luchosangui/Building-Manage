﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApartmentManagement : GenericRepository<Apartment>
    {
        public ApartmentManagement(DbContext context)
        {
            Context = context;
        }
    }
}