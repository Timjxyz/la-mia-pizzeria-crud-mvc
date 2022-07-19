using System.ComponentModel.DataAnnotations;
namespace la_mia_pizzeria_static.ValidationAttributes
{

    public class ValidatorPizzaForm : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string fieldValue = (string)value;
            if (fieldValue == null || fieldValue.Trim().IndexOf(" ") == -1)
            {
                return new ValidationResult("Il campo deve contenere almeno 5 parole");
            }
            return ValidationResult.Success;
        }
    }
}
