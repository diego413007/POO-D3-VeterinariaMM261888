using System.ComponentModel.DataAnnotations;

namespace VeterinariaWeb.Models
{
    public class Mascota
    {
        // [Key] hace que el scaffolding reconozca esta propiedad como la clave
        // y genere bien los enlaces Edit / Details / Delete en la vista Index.
        [Key]
        [Display(Name = "Id")]
        public int IdMascota { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La especie es obligatoria")]
        public string Especie { get; set; } = string.Empty;

        [Required(ErrorMessage = "La raza es obligatoria")]
        public string Raza { get; set; } = string.Empty;

        // M = macho, H = hembra
        [Required(ErrorMessage = "El sexo es obligatorio")]
        public string Sexo { get; set; } = string.Empty;

        [Display(Name = "Peso (kg)")]
        [Range(0.01, 200, ErrorMessage = "El peso debe estar entre 0.01 y 200 kg")]
        public decimal PesoKg { get; set; }

        [Required(ErrorMessage = "El propietario es obligatorio")]
        public string Propietario { get; set; } = string.Empty;

        [Display(Name = "Fecha de ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaIngreso { get; set; }
    }
}