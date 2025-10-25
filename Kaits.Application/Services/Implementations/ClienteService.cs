using AutoMapper;
using Kaits.Application.Dtos.Clientes;
using Kaits.Domain.Models;
using Kaits.Domain.Repositories;
using System.Linq.Expressions;

namespace Kaits.Application.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ClienteDto>> FindAllAsync()
        {
            IReadOnlyList<Cliente> productos = await _clienteRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<ClienteDto>>(productos);
        }

        public async Task<ClienteDto> FindByIdAsync(int id)
        {
            Expression<Func<Cliente, bool>> predicate = x => x.Id == id;

            Cliente? producto = await _clienteRepository.FindByIdAsync(predicate: predicate);

            return _mapper.Map<ClienteDto>(producto);
        }
    }
}
