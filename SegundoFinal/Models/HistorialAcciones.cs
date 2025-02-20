using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoFinal.Models
{
    public class HistorialAcciones
    {
        public int Id { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("UsuarioId")] public Cliente cliente { get; set; }
        public int UsuarioId { get; set; }
        public string Descripcion { get; set; }
        public string EntidadAfectada { get; set; }
        //(Nombre de la entidad afectada, como "Producto", "OrdenCompra", etc.)

    }
}
