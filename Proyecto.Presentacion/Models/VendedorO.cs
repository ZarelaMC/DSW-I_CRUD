using System.ComponentModel;

//para el Required
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Presentacion.Models
{
    public class VendedorO
    {
        [DisplayName("CÓDIGO")]
        public int ide_ven { get; set; }

        [DisplayName("NOMBRES")]
        [Required(ErrorMessage="Ingrese los nombres")]
        public string ? nom_ven { get; set; }

        [DisplayName("APELLIDOS")]
        [Required(ErrorMessage = "Ingrese los apellidos")]
        public string ? ape_ven { get; set; }

        [DisplayName("SUELDO")]
        [Required(ErrorMessage = "Ingrese el sueldo")]
        public Double sue_ven { get; set; }

        [DisplayName("FECHA DE INGRESO")]
        [Required(ErrorMessage = "Ingrese la fecha de ingreso")]
        public DateTime fec_ing { get; set; }

        [DisplayName("ID DISTRITO")]
        [Required(ErrorMessage = "Ingrese el distrito")]
        public int ide_dis { get; set; }
    }
}
