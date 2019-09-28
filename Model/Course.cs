using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursos.Model
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [MaxLength(500, ErrorMessage = "El número máximo de caracteres permitidos es de 500")]
        [Display(Name = "Descripción del curso")]
        public string Description { get; set; }
        [Required(ErrorMessage = "El autor es requerido")]
        [Display(Name = "Autor")]
        public string Author { get; set; }
        [Url(ErrorMessage = "La URL no es válida")]
        public string Uri { get; set; }
    }
}
