using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Presentacion.Models
{
    public class ClienteO
    {
        [DisplayName("CÓDIGO")]
        public int ide_cli { get; set; }

        [DisplayName("RAZÓN SOCIAL")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? rso_cli { get; set; }

        [DisplayName("DIRECCIÓN")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? dir_cli { get; set; }

        [DisplayName("TELÉFONO")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? tlf_cli { get; set; }

        [DisplayName("RUC")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? ruc_cli { get; set; }

        [DisplayName("ID DISTRITO")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int ide_dis { get; set; }

        [DisplayName("FECHA DE REGISTRO")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public DateTime fec_reg { get; set; }

        [DisplayName("REPRESENTANTE")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? con_cli { get; set; }
    }
}
