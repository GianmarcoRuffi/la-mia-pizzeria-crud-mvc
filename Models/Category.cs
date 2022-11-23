using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Category
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [StringLength(40, ErrorMessage = "La categoria non può contenere oltre i 40 caratteri.")]
        public string Name { get; set; }

        public List<Pizza> Pizzas { get; set;}

    

    }
}
