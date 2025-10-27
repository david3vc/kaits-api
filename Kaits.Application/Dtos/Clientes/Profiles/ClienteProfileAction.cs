using AutoMapper;
using Kaits.Domain.Models;

namespace Kaits.Application.Dtos.Clientes.Profiles
{
    public class ClienteProfileAction : IMappingAction<Cliente, ClienteDto>
    {
        public void Process(Cliente source, ClienteDto destination, ResolutionContext context)
        {
            destination.NombreCompleto = $"{source.Nombres} {source.ApellidoPaterno} {source.ApellidoMaterno}";
        }
    }
}
