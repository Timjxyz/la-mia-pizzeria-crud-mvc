using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Category
    {
        public Category()
        {


        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Il campo è obbligatorio")]
        [StringLength(20, ErrorMessage = "Il numero massimo di caratteri inseribili è 20 caratteri")]
        public string Name { get; set; }        
        public List<Pizza> Pizzas { get; set; }
    }
}

