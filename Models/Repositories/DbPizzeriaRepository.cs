using Azure;
using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models.Form;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Server;

namespace la_mia_pizzeria_static.Models.Repositories
{
    public class DbPizzeriaRepository : IDbPizzeriaRepository

    {

        PizzaDbContext db;
       

        public DbPizzeriaRepository()
        {
            db = new PizzaDbContext();
        }

        public List<Pizza> All()
        {
            return db.Pizzas.Include(pizza => pizza.Category).Include(pizza => pizza.Ingrediente).ToList();
        }

        public Pizza GetById(int id)
        {
            return db.Pizzas.Where(p => p.Id == id).Include("Category").Include("Ingrediente").FirstOrDefault();
        }

        public void Create(Pizza pizza, List<int> IngredientiSelezionati)
        {

            // associazione tag selezionati dall'utente al modello
            pizza.Ingrediente = new List<Ingrediente>();
            foreach (int IngredienteId in IngredientiSelezionati)
            {

                Ingrediente ingrediente = db.Ingredienti.Where(item => item.Id == IngredienteId).FirstOrDefault();
               pizza.Ingrediente.Add(ingrediente);

            }

            db.Pizzas.Add(pizza);
            db.SaveChanges();
        }




        public void Modifica(Pizza pizza, Pizza formData, List<int>? IngredientiSelezionati)
        {
            if (IngredientiSelezionati == null)
            {
                IngredientiSelezionati = new List<int>();
            }

            pizza.Name = formData.Name;
            pizza.Description = formData.Description;
            pizza.Prezzo = formData.Prezzo;
            pizza.Image = formData.Image;
            pizza.CategoryId = formData.CategoryId;
            pizza.Ingrediente.Clear();


            foreach (int ingredienteId in IngredientiSelezionati)
            {
                Ingrediente ingrediente = db.Ingredienti.Where(item => item.Id == ingredienteId).FirstOrDefault();
                pizza.Ingrediente.Add(ingrediente);
            }

            db.SaveChanges();

        }




        public void Delete(Pizza pizza)
        {
            db.Pizzas.Remove(pizza);
            db.SaveChanges();
        }

    }
}
