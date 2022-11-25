using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Ingrediente
    {

        public int Id { get; set; }
        public string Name { get; set; }


        // many to many con pizzas
        public List<Pizza>? Pizzas { get; set;}

    

    }
}
