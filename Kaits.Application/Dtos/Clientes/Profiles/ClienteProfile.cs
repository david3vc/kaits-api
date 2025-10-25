using AutoMapper;
using Kaits.Domain.Models;

namespace Kaits.Application.Dtos.Clientes.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteDto>();
        }
    }
}
