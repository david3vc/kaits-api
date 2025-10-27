using AutoMapper;
using Kaits.Application.Cores.Dtos;
using Kaits.Application.Cores.Exceptions;
using Kaits.Application.Dtos.Clientes;
using Kaits.Domain.Cores.Models;
using Kaits.Domain.Models;
using Kaits.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Kaits.Application.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ILogger<ClienteService> _logger;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper, ILogger<ClienteService> logger)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IReadOnlyList<ClienteDto>> FindAllAsync()
        {
            IReadOnlyList<Cliente> productos = await _clienteRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<ClienteDto>>(productos);
        }

        public async Task<PageResponse<ClienteDto>> FindAllPaginatedAsync(PageRequest<ClienteFilterDto> request)
        {
            var filter = request.Filter ?? new ClienteFilterDto();
            var paging = new Paging() { PageNumber = request.Page, PageSize = request.PerPage };

            Expression<Func<Cliente, bool>> predicate = x =>
                (string.IsNullOrWhiteSpace(filter.Nombres) || x.Nombres.ToUpper().Contains(filter.Nombres.ToUpper()))
                && (string.IsNullOrWhiteSpace(filter.ApellidoPaterno) || x.ApellidoPaterno.ToUpper().Contains(filter.ApellidoPaterno.ToUpper()))
                && (string.IsNullOrWhiteSpace(filter.ApellidoMaterno) || x.ApellidoMaterno.ToUpper().Contains(filter.ApellidoMaterno.ToUpper()))
                && (string.IsNullOrWhiteSpace(filter.Dni) || x.Dni.ToUpper().Contains(filter.Dni.ToUpper()))
                && (!filter.Estado.HasValue || x.Estado == filter.Estado);

            var response = await _clienteRepository.FindAllPaginatedAsync(paging: paging, predicate: predicate);

            return _mapper.Map<PageResponse<ClienteDto>>(response);
        }

        public async Task<ClienteDto> FindByIdAsync(int id)
        {
            Expression<Func<Cliente, bool>> predicate = x => x.Id == id;

            Cliente? cliente = await _clienteRepository.FindByIdAsync(predicate: predicate);

            if (cliente is null)
            {
                _logger.LogWarning("Cliente no encontrado para el id: " + id);
                throw ClienteNotFound(id);
            }

            return _mapper.Map<ClienteDto>(cliente);
        }

        private NotFoundCoreException ClienteNotFound(int id)
        {
            return new NotFoundCoreException("Cliente no encontrado para el id: " + id);
        }
    }
}
