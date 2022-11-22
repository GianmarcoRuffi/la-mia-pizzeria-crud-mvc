using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller

 
    {
        public IActionResult Index()
        {
            PizzaDbContext db = new PizzaDbContext();

            List<Pizza> listaPizza = db.Pizzas.ToList();

        return View(listaPizza);
        }

        public IActionResult Dettaglio(int Id)
        {

            PizzaDbContext db = new PizzaDbContext();

            Pizza pizza = db.Pizzas.Where(item => item.Id == Id).FirstOrDefault();

            return View(pizza);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            PizzaDbContext db = new PizzaDbContext();

            if (!ModelState.IsValid)
            {
                return View("Create", pizza);
            }

            else

            db.Pizzas.Add(pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Modifica(int id)

        {
            PizzaDbContext db = new PizzaDbContext();

            Pizza pizzaDaModificare = db.Pizzas.Where(item => item.Id == id).FirstOrDefault();

            if (pizzaDaModificare == null)
                return NotFound();
            else
            return View(pizzaDaModificare);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Modifica(Pizza pizza)

        { PizzaDbContext db = new PizzaDbContext();
               if (!ModelState.IsValid)
            {
                return View();
            }
            db.Pizzas.Update(pizza);
            db.SaveChanges();
            return RedirectToAction("Index");



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (int id)

        { PizzaDbContext db = new PizzaDbContext();
            Pizza pizzaDaEliminare= db.Pizzas.Where(item => item.Id == id).FirstOrDefault();
            if (pizzaDaEliminare != null)
            {

                db.Pizzas.Remove(pizzaDaEliminare);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            else
            return NotFound();
    


        }


    }



}
