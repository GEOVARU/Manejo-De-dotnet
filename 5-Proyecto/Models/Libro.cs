using System;
using System.ComponentModel.DataAnnotations;


namespace _5_Proyecto.Models
{
    public class Libro
    {
        // genera la llave primaria - siempre tiene que ir como ID
        [Key]
        public int Id { get; set; }//variables que iran en la base de datos

        [Required(ErrorMessage = "El titulo es obligatorio")]//campo requerido
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]//tiene que tener datos
        [Display(Name = "Título")]
        public String Titulo { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Descripción")]
        public String Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha de lanzamiento es obligatorio")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio")]
        public String Autor { get; set; }
 
        [Required(ErrorMessage = "El precio es obligatorio")]
        public int precio { get; set; }
    }
}
