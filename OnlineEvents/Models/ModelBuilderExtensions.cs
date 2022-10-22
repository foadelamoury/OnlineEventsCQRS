using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineEvents.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

               new Category
               {
                   Id = 1,
                   Name = "Category1",
                   Description = "Test Category",
                 
               }


               );
        }
    }
}

