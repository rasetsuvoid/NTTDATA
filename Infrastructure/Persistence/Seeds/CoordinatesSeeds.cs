using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public static class CoordinatesSeeds
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coordinates>().HasData(
                new Coordinates
                {
                    Id = 1,
                    Longitude = 123.456789m,
                    Latitude = 45.678901m,
                    CreatedDate = DateTime.Now,
                    Active = true,
                    IsDeleted = false,
                    UpdateDate = null
                }
            );
        }
    }
}
