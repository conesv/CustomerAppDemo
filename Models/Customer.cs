using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CustomerApp.Models
{
    public partial class Customer
    {
        [DisplayName("Customer Id")]
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [StringLength(25)]
        //[Required(ErrorMessage = "El nombre es un campo obligatorio")]
        public string FirstName { get; set; }

        [DisplayName("Apellido")]
        [StringLength(25)]
        //[Required(ErrorMessage = "El apellido es un campo obligatorio")]
        public string LastName { get; set; }

        [DisplayName("Direccion")]
        [StringLength(75)]
        //[Required(ErrorMessage = "La direccion es un campo obligatorio")]
        public string Address { get; set; }

        [DisplayName("Telefono")]
        [StringLength(15)]
        [Required(ErrorMessage = "El apellido es un campo obligatorio")]
        public string? Phone { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Porfavor, ingrese un email valido")]
        public string Email { get; set; }

        [DisplayName("Estatus")]
        [Required(ErrorMessage = "Registre el estatus del usuario")]
        public bool status { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
