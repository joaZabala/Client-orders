using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoFinal.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public int Stock { get; set; }

        [ForeignKey("CategoriaId")] public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

    }
}
