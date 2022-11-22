using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller

 
    {


        PizzaDbContext db;

        public PizzaController() : base()
        {
            db = new PizzaDbContext();
        }


        public IActionResult Index()
        {
            

            List<Pizza> listaPizza = db.Pizzas.ToList();

        return View(listaPizza);
        }

        public IActionResult Dettaglio(int Id)
        {

            

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
            

            Pizza pizza = db.Pizzas.Where(item => item.Id == id).FirstOrDefault();

            if (pizza == null)
                return NotFound();
            else
            return View(pizza);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Modifica(Pizza pizza)

        { 
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
