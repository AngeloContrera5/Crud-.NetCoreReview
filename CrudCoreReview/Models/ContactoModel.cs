using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrudCoreReview.Models
{
    public class ContactoModel
    {
        public int idContacto { get; set; }

        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        public string nomContacto { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string telContacto { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string correoContacto { get; set; }
    }
}
