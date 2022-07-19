using la_mia_pizzeria_static.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("pizza")]
public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }
        [StringLength(20, ErrorMessage ="Il numero massimo di caratteri inseribili è 20 caratteri")]
        [Required(ErrorMessage ="Il campo è obbligatorio")]
        public string Name { get; set; }
        [ValidatorPizzaForm]
        [StringLength(100, ErrorMessage = "Il numero massimo di caratteri inseribili è 100 caratteri")]
        public string Description { get; set; }
       
        public string Img { get; set; }
        [Range(1, 100, ErrorMessage = "Il prezzo selezionato non è valido, min 1/ max 100")]
        public double Price { get; set; }
    public Pizza()
    {

    }
}

