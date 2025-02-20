using AutoMapper;
using SegundoFinal.DTOs;
using SegundoFinal.Models;
using SegundoFinal.Repositories;
using SegundoFinal.Response;

namespace SegundoFinal.Services
{
    public class ClienteService
    {

        private readonly ClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private int _id = 0;
        public ClienteService(ClienteRepository clienteRepository , IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }


        public async Task<ApiResponse<Cliente>> GetClientesById(int id)
        {
            var response = new ApiResponse<Cliente>();

            try
            {
                var cliente = await _clienteRepository.GetById(id);
                if (cliente == null) { 
                
                    response.SetError("No existe el clinete con el id" , System.Net.HttpStatusCode.NotFound );
                }
                else
                {
                    response.Data = cliente;
                }
            }
            catch (Exception ex) { 
                    response.SetError(ex.Message, System.Net.HttpStatusCode.InternalServerError );

            }
            return response;
        }

        public async Task<ApiResponse<Cliente>> CreateCliente(RequestClienteDTO requestClienteDTO)
        {
            var response = new ApiResponse<Cliente>();

            try
            {

                var clienteCreated = _mapper.Map<Cliente>(requestClienteDTO);
                clienteCreated.Id = _id++;
                clienteCreated.FechaRegistro = DateTime.Now;
                clienteCreated.Estado = true;

                var cliente = await _clienteRepository.CreateClient(clienteCreated);

                response.Data = cliente;

            }
            catch (Exception ex)
            {
                response.SetError(ex.Message, System.Net.HttpStatusCode.InternalServerError);

            }
            return response;
        }
    }
}
