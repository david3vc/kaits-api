using AutoMapper;
using Kaits.Application.Cores.Dtos;
using Kaits.Domain.Cores.Models;
using Kaits.Domain.Models;

namespace Kaits.Application.Dtos.Clientes.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<Cliente, ClienteFilterDto>().ReverseMap();

            CreateMap<PagedResult<Cliente>, PageResponse<ClienteDto>>();
        }
    }
}
