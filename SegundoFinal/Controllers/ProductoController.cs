using Microsoft.AspNetCore.Mvc;
using SegundoFinal.DTOs;
using SegundoFinal.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SegundoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productService;

        public ProductoController(ProductoService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var response = await _productService.GetProducts();

            if (response.Success) {
            
            return Ok(response);
            }

            return BadRequest(response);
            
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _productService.GetById(id);

            if (response.Success)
            {

                return Ok(response);
            }

            return BadRequest(response);
        }


        // GET api/<ProductoController>/5
        [HttpGet("categoria/{id}")]
        public async Task<IActionResult> GetByCategoria(int id)
        {
            var response = await _productService.GetByCategoriaId(id);

            if (response.Success)
            {

                return Ok(response);
            }

            return BadRequest(response);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoRequest value)
        {
            var response = await _productService.AddProduct(value);

            if (response.Success)
            {

                return Ok(response);
            }

            return BadRequest(response);

        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductoRequest value)
        {
            var response = await _productService.UpdateProduct(id , value);

            if (response.Success)
            {

                return Ok(response);
            }

            return BadRequest(response);
        }

    }
}
