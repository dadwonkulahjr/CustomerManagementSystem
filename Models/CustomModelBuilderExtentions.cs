using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Models
{
    public static class CustomModelBuilderExtentions
    {
        public static void SeedDatabaseWithInitialData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity(typeof(Customer)).HasData(
                new Customer() { Id = 1, Name = "Crystal M Jones", Email = "cjones@outlook.com", Gender = Gender.Female },
                new Customer() { Id = 2, Name = "Precious K Wonkulah", Email = "wonkulahp@outlook.com", Gender = Gender.Female }
                );
        }
    }
}
