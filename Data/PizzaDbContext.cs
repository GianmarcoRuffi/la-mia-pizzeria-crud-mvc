using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
namespace la_mia_pizzeria_static.Data



{
    public class PizzaDbContext : DbContext
    {

        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Ingrediente> Ingredienti { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog =db-pizzeria; Integrated Security=True; Encrypt=false;");
        }
    }
}
