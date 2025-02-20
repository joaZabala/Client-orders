using Microsoft.EntityFrameworkCore;
using SegundoFinal.Models;

namespace SegundoFinal.Data
{
    public class ContextDb : DbContext
    {

        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {

        }

        public DbSet<Categoria>Categorias { get; set; }
        public DbSet<Producto>Productos { get; set; }
        public DbSet<OrdenCompra>OrderCompras { get; set; }
        public DbSet<Cliente>Clientes { get; set; }
        public DbSet<HistorialAcciones>HistorialAcciones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Categoria>().HasData(

               new Categoria
               {
                   Id = 1,
                   Nombre = "Deportes",
                   Descripcion = "productos de deportes",
                   FechaCreacion = DateTime.Today
               }

           );
            base.OnModelCreating(modelBuilder);
        }
    }
}
