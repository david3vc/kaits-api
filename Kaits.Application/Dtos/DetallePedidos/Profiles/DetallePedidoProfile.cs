using AutoMapper;
using Kaits.Domain.Models;

namespace Kaits.Application.Dtos.DetallePedidos.Profiles
{
    public class DetallePedidoProfile : Profile
    {
        public DetallePedidoProfile()
        {
            CreateMap<DetallePedido, DetallePedidoDto>();
            CreateMap<DetallePedido, DetallePedidoSaveDto>().ReverseMap();
        }
    }
}
