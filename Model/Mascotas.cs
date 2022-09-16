using System.ComponentModel.DataAnnotations;

namespace ApisCrud.Model
{
    public class Mascotas
    {
        [Key]
        public int idMascotas { get; set; }
        [Required]
        public string? nombreMascota { get; set; }
        [Required]
        public string? razaMascota { get; set; }
        [Required]
        public int edadMascota { get; set; }
    }
}
