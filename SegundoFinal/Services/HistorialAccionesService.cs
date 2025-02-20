using AutoMapper;
using SegundoFinal.Data;
using SegundoFinal.DTOs;
using SegundoFinal.Models;
using SegundoFinal.Repositories;
using SegundoFinal.Response;

namespace SegundoFinal.Services
{
    public class HistorialAccionesService
    {
        private readonly HistorialAccionesRepository _repository;
        private readonly IMapper _mapper;
        private int _id = 0;

        public HistorialAccionesService(HistorialAccionesRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<HistorialAcciones>> CreateHistorialAcciones(HistorialRequest historialAccionesRequest)
        { 
            var response = new ApiResponse<HistorialAcciones>();

            try
            { 
                var mapped = _mapper.Map<HistorialAcciones>(historialAccionesRequest);
                mapped.Id = _id++;
                mapped.Fecha = DateTime.Now;

                var historial = await _repository.CreateHistorialAcciones(mapped);

                response.Data = historial;
            }
            catch (Exception ex) { 

                response.SetError(ex.Message , System.Net.HttpStatusCode.InternalServerError);
            }
            return response;    
        }

        public async Task<ApiResponse<List<HistorialAcciones>>> GetHistorial(int id , string entidadAfectada)
        {
            var response = new ApiResponse<List<HistorialAcciones>>();

            try
            {
                var historial = await _repository.GetHistorial(id , entidadAfectada);

                response.Data = historial;
            }
            catch (Exception ex)
            {

                response.SetError(ex.Message, System.Net.HttpStatusCode.InternalServerError);
            }
            return response;
        }
    }
}
