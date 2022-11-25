using Azure;
using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Form;
using la_mia_pizzeria_static.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Server;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller

    {

        PizzaDbContext db;
        IDbPizzeriaRepository pizzeriaRepository;


        public PizzaController() : base()
        {
            db = new PizzaDbContext();
            pizzeriaRepository = new DbPizzeriaRepository();
        }


        public IActionResult Index()
        {
            List<Pizza> pizze = pizzeriaRepository.All();
            return View(pizze);
        }

        public IActionResult Dettaglio(int id)
        {
            
                Pizza pizza = pizzeriaRepository.GetById(id);
                if (pizza == null)
                    return NotFound();
            else

            return View(pizza);
        }


        //public IActionResult Index()
        //{


        //    List<Pizza> listaPizza = db.Pizzas.Include("Category").ToList();

        //return View(listaPizza);
        //}

        //public IActionResult Dettaglio(int Id)
        //{



        //    Pizza pizza = db.Pizzas.Where(item => item.Id == Id).Include("Category").Include("Ingrediente").FirstOrDefault();

        //    return View(pizza);
        //}

        [HttpGet]
        public IActionResult Create()

        {
            PizzaForm formData = new PizzaForm();

            formData.Pizza = new Pizza();
            formData.Categories = db.Categories.ToList();
            formData.Ingredienti = new List<SelectListItem>();

            List<Ingrediente> ListaIngredienti = db.Ingredienti.ToList();

            foreach (Ingrediente ingrediente in ListaIngredienti)
            {
                formData.Ingredienti.Add(new SelectListItem(ingrediente.Name, ingrediente.Id.ToString()));
            };
            return View(formData);
        }

        //{
        //    //List<Category> categories = db.Categories.ToList();

        //    //return View("Create");

        //    return View(formData);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaForm formData)
        {


            if (!ModelState.IsValid)
            {
                formData.Categories = db.Categories.ToList();
                formData.Ingredienti = new List<SelectListItem>();

                List<Ingrediente> ListaIngredienti = db.Ingredienti.ToList();

                foreach (Ingrediente ingrediente in ListaIngredienti)
                {
                    formData.Ingredienti.Add(new SelectListItem(ingrediente.Name, ingrediente.Id.ToString()));
                }
               
                return View(formData);
            }

            pizzeriaRepository.Create(formData.Pizza, formData.IngredientiSelezionati);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Modifica(int id)

        {

            Pizza pizza = db.Pizzas.Where(pizza => pizza.Id == id).Include(pizza => pizza.Ingrediente).FirstOrDefault();

            if (pizza == null)
                return NotFound();
            PizzaForm formData = new PizzaForm();

            formData.Pizza = pizza;
            formData.Categories = db.Categories.ToList();
            formData.Ingredienti = new List<SelectListItem>();

            List<Ingrediente> ListaIngredienti = db.Ingredienti.ToList();

            foreach (Ingrediente ingrediente in ListaIngredienti)
            {   
                formData.Ingredienti.Add(new SelectListItem(
                    ingrediente.Name,
                    ingrediente.Id.ToString(),
                    pizza.Ingrediente.Any(i => i.Id == ingrediente.Id)
                   ));
            }

            return View(formData);

            //PizzaForm formData = new PizzaForm();
            //formData.Pizza = db.Pizzas.Where(item => item.Id == id).FirstOrDefault();

            //if (formData.Pizza == null)
            //    return NotFound();

            //else

            //formData.Categories = db.Categories.ToList();
            // return View(formData);
        }


        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Modifica(int id, PizzaForm formData)

        {
          
            if (!ModelState.IsValid)
            {
                formData.Pizza.Id = id;
                formData.Categories = db.Categories.ToList();
                formData.Ingredienti = new List<SelectListItem>();

                List<Ingrediente> ListaIngredienti = db.Ingredienti.ToList();

                foreach (Ingrediente ingrediente in ListaIngredienti)
                {
                    formData.Ingredienti.Add(new SelectListItem(ingrediente.Name, ingrediente.Id.ToString()));
                }

                return View(formData);
            }

            Pizza pizza = db.Pizzas.Where(pizza => pizza.Id == id).Include(pizza => pizza.Ingrediente).FirstOrDefault();

            //if (pizza == null)
            //{
            //    return NotFound();
            //}


            db.Pizzas.Update(formData.Pizza);

            //pizza.Name = formData.Pizza.Name;
            //pizza.Description = formData.Pizza.Description;
            //pizza.Image = formData.Pizza.Image;
            //pizza.Prezzo = formData.Pizza.Prezzo;
            //pizza.CategoryID = formData.Pizza.CategoryID;
            pizza.Ingrediente.Clear();

            if (formData.IngredientiSelezionati == null)
            {
                formData.IngredientiSelezionati = new List<int>();
            }

            foreach (int ingredientId in formData.IngredientiSelezionati)
            {
                Ingrediente ingrediente = db.Ingredienti.Where(i => i.Id == ingredientId).FirstOrDefault();
                pizza.Ingrediente.Add(ingrediente);
            }



      
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (int id)

        { 
            Pizza pizza = db.Pizzas.Where(item => item.Id == id).FirstOrDefault();
            if (pizza == null)
            
                return NotFound();

            else

                db.Pizzas.Remove(pizza);
                db.SaveChanges();
               return RedirectToAction("Index");



        }

       


    }



}
