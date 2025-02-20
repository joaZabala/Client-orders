using Microsoft.AspNetCore.Mvc;
using SegundoFinal.DTOs;
using SegundoFinal.Repositories;
using SegundoFinal.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SegundoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialAccionesController : ControllerBase
    {

        private readonly HistorialAccionesService _historialAccionesService;

        public HistorialAccionesController(HistorialAccionesService historialAccionesService)
        {
            _historialAccionesService = historialAccionesService;
        }
        // GET: api/<HistorialAccionesController>
        [HttpGet]
        public async Task<IActionResult> Get(int id , string entidad )
        {
            var response = await _historialAccionesService.GetHistorial(id, entidad);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        // POST api/<HistorialAccionesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HistorialRequest value)
        {
            var response = await _historialAccionesService.CreateHistorialAcciones(value);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

    }
}
