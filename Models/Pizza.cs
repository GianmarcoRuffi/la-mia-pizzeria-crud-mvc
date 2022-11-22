using la_mia_pizzeria_static.ValidationCustomClasses;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La pizza deve avere un nome")]
        [StringLength(40, ErrorMessage = "Il nome non può avere più di 40 caratteri")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "La pizza deve avere una descrizione")]
        [StringLength(300, ErrorMessage = "La descrizione non può avere più di 300 caratteri")]
        [FiveWordsValidation]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Devi inserire un link all'immagine della pizza")]
        [StringLength(500, ErrorMessage = "Il link non può avere più di 500 caratteri")]
        public string? Image { get; set; }

        [Required(ErrorMessage = "La pizza deve avere un prezzo valido")]
        [Range(1, 500, ErrorMessage = "La pizza deve avere un prezzo valido")]
        public double? Prezzo { get; set; }


        public Pizza() {
        }

        public Pizza(string name, string description, string image, double prezzo) {

            this.Name = name;
            this.Description = description;
            this.Image= image;
            this.Prezzo= prezzo;
}
    }







}
