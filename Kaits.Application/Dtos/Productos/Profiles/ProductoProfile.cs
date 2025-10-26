using AutoMapper;
using Kaits.Application.Cores.Dtos;
using Kaits.Domain.Cores.Models;
using Kaits.Domain.Models;

namespace Kaits.Application.Dtos.Productos.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<Producto, ProductoDto>();
            CreateMap<Producto, ProductoFilterDto>().ReverseMap();

            CreateMap<PagedResult<Producto>, PageResponse<ProductoDto>>();
        }
    }
}
