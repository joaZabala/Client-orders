using SegundoFinal.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoFinal.DTOs
{
    public class ProductoRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public int Stock { get; set; }
        public int CategoriaId { get; set; }

    }
}
