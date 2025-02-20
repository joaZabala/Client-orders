using Microsoft.EntityFrameworkCore;
using SegundoFinal.Data;
using SegundoFinal.Models;

namespace SegundoFinal.Repositories
{
    public class ProductoRepository
    {

        private readonly ContextDb _context;

        public ProductoRepository(ContextDb context)
        {
            _context = context;
        }


        public async Task<List<Producto>> GetProductos()
        {
            var productos = await _context.Productos.Include( p => p.Categoria).ToListAsync();

            return productos;
        }

        public async Task<Producto> CreateProductos(Producto producto)
        {

            var existCategoria = await _context.Categorias
                .FirstOrDefaultAsync(c => c.Id == producto.CategoriaId);

            if (existCategoria == null)
            {

                throw new Exception("No existe la categoria con el id " + producto.CategoriaId);
            }
            else
            {
                if (producto.Stock > 0 && producto.Precio > 0)
                {
                    producto.Categoria = existCategoria;

                    await _context.Productos.AddAsync(producto);
                    await _context.SaveChangesAsync();
                    return producto;
                }
                else
                {
                    throw new Exception("El precio y el stock deben ser mayores a 0");
                }
            }  
        }

        public async Task<Producto?> GetById(int id)
        {

            var producto = await _context.Productos.Include(c => c.Categoria)
                .FirstOrDefaultAsync( p => p.Id == id);

            return producto;
        }

        public async Task<List<Producto>> GetByCategoria(int idCategoria)
        { 
            var producto = await _context.Productos.Include(c => c.Categoria)
                .Where(c =>c.CategoriaId == idCategoria).ToListAsync();

            return producto;
        }

        public async Task<Producto> UpdateProductos(int id , Producto producto)
        {
            var existProducto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);

            if (existProducto == null) {
                throw new Exception("No existe el prodcuto con el id " +id);
            }

            var existCategoria = await _context.Categorias
                .FirstOrDefaultAsync(c => c.Id == producto.CategoriaId);

            if (existCategoria == null)
            {

                throw new Exception("No existe la categoria con el id " + producto.CategoriaId);
            }
            else
            {
                if (producto.Stock > 0 && producto.Precio > 0)
                {
                    existProducto.Categoria = existCategoria;
                    existProducto.Descripcion = producto.Descripcion;
                    existProducto.Nombre = producto.Nombre;

                
                    await _context.SaveChangesAsync();
                    return producto;
                }
                else
                {
                    throw new Exception("El precio y el stock deben ser mayores a 0");
                }
            }
        }

    }
}
