using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoFinal.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; } = null;
    }
}
