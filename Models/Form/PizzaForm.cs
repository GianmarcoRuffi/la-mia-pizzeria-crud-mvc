using Microsoft.AspNetCore.Mvc.Rendering;

namespace la_mia_pizzeria_static.Models.Form
{
    public class PizzaForm
    {

        public Pizza? Pizza { get; set; }

        public List<Category>? Categories { get; set; }


        // views: create, update
        public List<SelectListItem>? Ingredienti { get; set; }

        // model: create, update
        public List<int>? IngredientiSelezionati { get; set; }

        //public PizzaForm() {

        //    IngredientiSelezionati = new List<int>();
        //}



    }
}
