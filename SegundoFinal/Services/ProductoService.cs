using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SegundoFinal.DTOs;
using SegundoFinal.Models;
using SegundoFinal.Repositories;
using SegundoFinal.Response;

namespace SegundoFinal.Services
{
    public class ProductoService
    {

        private readonly ProductoRepository _productoRepository;
        private readonly IMapper _mappper;

        private int _id = 0;

        public ProductoService(ProductoRepository productoRepository , IMapper mappper)
        {
            _productoRepository = productoRepository;
            _mappper = mappper;
        }


        public async Task<ApiResponse<List<ProductoDTO>>> GetProducts()
        {
            var response = new ApiResponse<List<ProductoDTO>>();

            try
            {
                var productos = await _productoRepository.GetProductos();

                var mappedResponse = _mappper.Map<List<ProductoDTO>>(productos);

                response.Data = mappedResponse;

            }
            catch (Exception ex) { 
            
            response.SetError(ex.Message , System.Net.HttpStatusCode.NotFound);
            }
            return response;
        }


        public async Task<ApiResponse<ProductoDTO>> AddProduct(ProductoRequest productoRequest)
        {
            var response = new ApiResponse<ProductoDTO>();

            try
            {
                var map = _mappper.Map<Producto>(productoRequest);
                map.Id = _id++;
                map.FechaCreacion = DateTime.Now;

                var producto = await _productoRepository.CreateProductos(map);
                
                response.Data = _mappper.Map<ProductoDTO>(producto);
            }
            catch (Exception ex)
            {

                response.SetError(ex.Message, System.Net.HttpStatusCode.NotFound);
            }
            return response;
        }

        public async Task<ApiResponse<ProductoDTO>> UpdateProduct(int id , ProductoRequest productoRequest)
        {
            var response = new ApiResponse<ProductoDTO>();  

            try
            {
                var map = _mappper.Map<Producto>(productoRequest);
                map.FechaModificacion = DateTime.Now;

                var producto = await _productoRepository.UpdateProductos(id , map);

                response.Data = _mappper.Map<ProductoDTO>(producto);
            }
            catch (Exception ex)
            {

                response.SetError(ex.Message, System.Net.HttpStatusCode.NotFound);
            }
            return response;
        }

        public async Task<ApiResponse<ProductoDTO>> GetById(int id)
        {
            var response = new ApiResponse<ProductoDTO>();

            try
            {
                var producto = await _productoRepository.GetById(id);

                if(producto != null)
                {
                    var mapped = _mappper.Map<ProductoDTO>(producto);
                    response.Data = mapped;
                }
                else
                {
                    response.SetError("No existe el producto especificado" , System.Net.HttpStatusCode.NotFound );
                }

            }
            catch (Exception ex) {

                response.SetError(ex.Message, System.Net.HttpStatusCode.InternalServerError);
            }

            return response;
        }

        public async Task<ApiResponse<List<ProductoDTO>>> GetByCategoriaId(int idCategoria)
        {
            var response = new ApiResponse<List<ProductoDTO>>();

            try
            {
                var producto = await _productoRepository.GetByCategoria(idCategoria);
                    var mapped = _mappper.Map<List<ProductoDTO>>(producto);
                    response.Data = mapped;

            }
            catch (Exception ex)
            {

                response.SetError(ex.Message, System.Net.HttpStatusCode.InternalServerError);
            }

            return response;
        }

    }
}
