using SegundoFinal.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoFinal.DTOs
{
    public class HistorialRequest
    {
        public string Accion { get; set; }
        public int UsuarioId { get; set; }
        public string Descripcion { get; set; }
        public string EntidadAfectada { get; set; }
    }
}
