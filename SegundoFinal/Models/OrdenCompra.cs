namespace SegundoFinal.Models
{
    public class OrdenCompra
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }//(Valores posibles: "Pendiente", "Completada", "Cancelada") 

        public DateTime? FechaEntrega { get; set; }

    }
}
