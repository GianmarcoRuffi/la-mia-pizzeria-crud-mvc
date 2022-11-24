﻿using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Form;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

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
            

            List<Pizza> listaPizza = db.Pizzas.Include("Category").ToList();

        return View(listaPizza);
        }

        public IActionResult Dettaglio(int Id)
        {

            

            Pizza pizza = db.Pizzas.Where(item => item.Id == Id).Include("Category").FirstOrDefault();

            return View(pizza);
        }

        [HttpGet]
        public IActionResult Create()

        {

            PizzaForm formData  = new PizzaForm();

            formData.Pizza = new Pizza();
            formData.Categories= db.Categories.ToList();
            formData.Ingredienti = db.Ingredienti.ToList();


            //List<Category> categories = db.Categories.ToList();

            //return View("Create");

            return View(formData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaForm formData)
        {
            

            if (!ModelState.IsValid)
            {
                formData.Categories = db.Categories.ToList();
                return View(formData);
            }

            else

            db.Pizzas.Add(formData.Pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Modifica(int id)

        {

            PizzaForm formData = new PizzaForm();
            formData.Pizza = db.Pizzas.Where(item => item.Id == id).FirstOrDefault();

            if (formData.Pizza == null)
                return NotFound();


            else

        

          
            formData.Categories = db.Categories.ToList();
             return View(formData);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Modifica(int id, PizzaForm formData)

        {
            formData.Pizza.Id = id;
            if (!ModelState.IsValid)
            {
                formData.Categories = db.Categories.ToList();
                return View(formData);
            }
            db.Pizzas.Update(formData.Pizza);
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
