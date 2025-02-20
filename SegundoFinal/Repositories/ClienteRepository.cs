using Microsoft.EntityFrameworkCore;
using SegundoFinal.Data;
using SegundoFinal.Models;

namespace SegundoFinal.Repositories
{
    public class ClienteRepository
    {
        private readonly ContextDb _contextDb;

        public ClienteRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }


        public async Task<Cliente?> GetById(int clienteId)
        {
            var exist = await _contextDb.Clientes.FirstOrDefaultAsync( c => c.Id == clienteId);

            return exist;
                        
        }

        public async Task<Cliente> CreateClient(Cliente cliente)
        {
            var exist = await _contextDb.Clientes.FirstOrDefaultAsync( e => e.Email == cliente.Email );

            if (exist == null) { 
            
                await _contextDb.Clientes.AddAsync(cliente);
                await _contextDb.SaveChangesAsync();
                return cliente;
            }
            else
            {
                throw new Exception("Email No valido");
            }
        }
    }
}
