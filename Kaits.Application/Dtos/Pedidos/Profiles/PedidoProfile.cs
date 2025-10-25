using AutoMapper;
using Kaits.Application.Dtos.Clientes;
using Kaits.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
