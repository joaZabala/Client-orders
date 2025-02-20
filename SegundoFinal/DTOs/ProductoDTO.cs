using SegundoFinal.Models;

namespace SegundoFinal.DTOs
{
    public class ProductoDTO
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Categoria Categoria { get; set; }
    }
}
