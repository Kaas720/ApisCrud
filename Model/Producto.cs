using System.ComponentModel.DataAnnotations;

namespace ApisCrud.Model
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        [Required]
        public string? nombreProducto { get; set; }
        [Required]
        public double valorUnitario { get; set; }
    }
}
