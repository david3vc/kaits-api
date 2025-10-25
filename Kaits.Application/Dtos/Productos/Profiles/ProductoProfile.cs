using AutoMapper;
using Kaits.Domain.Models;

namespace Kaits.Application.Dtos.Productos.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<Producto, ProductoDto>();
        }
    }
}
