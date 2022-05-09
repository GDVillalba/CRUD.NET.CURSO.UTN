using System.ComponentModel.DataAnnotations;

namespace CRUDNETBDD.Models
{
    public class ModelCliente
    {
        //Estas son la representacion de los campos de la tabla Cliente
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingreasr un nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Ingreasr una direccion es obligatorio")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "Ingreasr poblacion es obligatorio")]
        public string? Poblacion { get; set; }

        [Required(ErrorMessage = "Ingreasr un telefono es obligatorio")]
        public string? Telefono { get; set; }
    }
}
