using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.ValidationCustomClasses
{
    public class FiveWordsValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            string fieldValue = (string)value;

            if (fieldValue == null || fieldValue.Trim().IndexOf(" ") == -1)
            {
                return new ValidationResult("La descrizione deve contenere almeno 5 parole.");
            }

            return ValidationResult.Success;
        }

    }
}
