using AutoMapper;
using Kaits.Application.Cores.Dtos;
using Kaits.Domain.Cores.Models;
using Kaits.Domain.Models;

namespace Kaits.Application.Dtos.Pedidos.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<Pedido, PedidoDto>();
            CreateMap<Pedido, PedidoSaveDto>().ReverseMap();
            CreateMap<Pedido, PedidoFilterDto>().ReverseMap();

            CreateMap<PagedResult<Pedido>, PageResponse<PedidoDto>>();
        }
    }
}
