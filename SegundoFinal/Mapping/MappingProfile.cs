using AutoMapper;
using SegundoFinal.DTOs;
using SegundoFinal.Models;

namespace SegundoFinal.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductoDTO, Producto>().ReverseMap();
            CreateMap<Producto, ProductoRequest>().ReverseMap();
            CreateMap<Cliente, RequestClienteDTO>().ReverseMap();
            CreateMap<HistorialAcciones, HistorialRequest>().ReverseMap();


        }
    }
}
