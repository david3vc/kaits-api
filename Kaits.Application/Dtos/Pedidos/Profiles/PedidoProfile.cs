using AutoMapper;
using Kaits.Domain.Models;

namespace Kaits.Application.Dtos.Pedidos.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<Pedido, PedidoDto>();
            CreateMap<Pedido, PedidoSaveDto>().ReverseMap();
        }
    }
}
