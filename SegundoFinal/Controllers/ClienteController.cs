using Microsoft.AspNetCore.Mvc;
using SegundoFinal.DTOs;
using SegundoFinal.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SegundoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;

        }


        // GET: api/<ClienteController>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get( int id)
        {
            var response = await _clienteService.GetClientesById(id);

            if (response.Success) { 
            
                return Ok(response);
            }
            return BadRequest(response);
        }

      
        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestClienteDTO value)
        {
            var response = await _clienteService.CreateCliente(value);

            if (response.Success)
            {

                return Ok(response);
            }
            return BadRequest(response);

        }
    }
}
