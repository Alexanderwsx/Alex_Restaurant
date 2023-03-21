using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Alex_Restaurant.Models;

namespace Alex_Restaurant.Data
{
    public class Alex_RestaurantContext : DbContext
    {
        public Alex_RestaurantContext (DbContextOptions<Alex_RestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<Alex_Restaurant.Models.TypeMeal> TypeMeal { get; set; } = default!;

        public DbSet<Alex_Restaurant.Models.Meal> Meal { get; set; } = default!;
    }
}
