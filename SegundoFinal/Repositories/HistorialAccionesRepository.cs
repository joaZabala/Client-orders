using Microsoft.EntityFrameworkCore;
using SegundoFinal.Data;
using SegundoFinal.Models;

namespace SegundoFinal.Repositories
{
    public class HistorialAccionesRepository
    {
        private readonly ContextDb _contextDb;
        public HistorialAccionesRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }


        public async Task<List<HistorialAcciones>>GetHistorial(int id , string entidadAfectada)
        { 
                var accionesByEntity = await _contextDb.HistorialAcciones.Include(h => h.cliente)
               .Where(ha => ha.EntidadAfectada.ToLower() == entidadAfectada.ToLower() 
               || (ha.UsuarioId == id)).ToListAsync();

            return accionesByEntity;          
        }



        public async Task<HistorialAcciones> CreateHistorialAcciones(HistorialAcciones historialAcciones)
        {
            var existeCliente = await _contextDb.Clientes
                .FirstOrDefaultAsync(c => c.Id == historialAcciones.UsuarioId);

            if (existeCliente == null)
            {
                throw new Exception("No existe el usuario con el id " + historialAcciones.UsuarioId);
            }
            else
            {
                historialAcciones.cliente = existeCliente;
                await _contextDb.HistorialAcciones.AddAsync(historialAcciones);
                await _contextDb.SaveChangesAsync();
                return historialAcciones;
            }
        }
    }
}
