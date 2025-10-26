using AutoMapper;
using Kaits.Application.Cores.Dtos;
using Kaits.Application.Cores.Exceptions;
using Kaits.Application.Dtos.Pedidos;
using Kaits.Application.Dtos.Productos;
using Kaits.Domain.Cores.Models;
using Kaits.Domain.Models;
using Kaits.Domain.Repositories;
using System.Linq.Expressions;

namespace Kaits.Application.Services.Implementations
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<PedidoDto> CreateAsync(PedidoSaveDto saveDto)
        {
            if (saveDto.IdCliente <= 0)
                throw new BadRequestCoreException("IdCliente es obligatoria.");

            Pedido pedido = _mapper.Map<Pedido>(saveDto);
            pedido.FechaCreacion = DateTime.UtcNow;
            pedido.Estado = true;

            await _pedidoRepository.SaveAsync(pedido);

            return _mapper.Map<PedidoDto>(pedido);
        }

        public async Task<PedidoDto> DisabledAsync(int id)
        {
            Pedido? pedido = await _pedidoRepository.FindByIdAsync(id);

            pedido.Estado = !pedido.Estado;

            await _pedidoRepository.SaveAsync(pedido);

            return _mapper.Map<PedidoDto>(pedido);
        }

        public async Task<PedidoDto> EditAsync(int id, PedidoSaveDto saveDto)
        {
            Pedido? pedido = await _pedidoRepository.FindByIdAsync(id);

            _mapper.Map<PedidoSaveDto, Pedido>(saveDto, pedido);

            pedido.FechaActualizacion = DateTime.UtcNow;

            await _pedidoRepository.SaveAsync(pedido);

            return _mapper.Map<PedidoDto>(pedido);
        }

        public async Task<IReadOnlyList<PedidoDto>> FindAllAsync()
        {
            IReadOnlyList<Pedido> pedidos = await _pedidoRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<PedidoDto>>(pedidos);
        }

        public async Task<PageResponse<PedidoDto>> FindAllPaginatedAsync(PageRequest<PedidoFilterDto> request)
        {
            var filter = request.Filter ?? new PedidoFilterDto();
            var paging = new Paging() { PageNumber = request.Page, PageSize = request.PerPage };

            Expression<Func<Pedido, bool>> predicate = x =>
                (!filter.Fecha.HasValue || x.Fecha == filter.Fecha)
                && (!filter.IdCliente.HasValue || x.IdCliente == filter.IdCliente)
                && (!filter.Total.HasValue || x.Total == filter.Total)
                && (!filter.Estado.HasValue || x.Estado == filter.Estado);

            var response = await _pedidoRepository.FindAllPaginatedAsync(paging: paging, predicate: predicate);

            return _mapper.Map<PageResponse<PedidoDto>>(response);
        }

        public async Task<PedidoDto> FindByIdAsync(int id)
        {
            List<Expression<Func<Pedido, object>>>? includes = new List<Expression<Func<Pedido, object>>>()
            {
                t => t.Cliente
            };
            Expression<Func<Pedido, bool>> predicate = x => x.Id == id;

            Pedido? pedido = await _pedidoRepository.FindByIdAsync(predicate: predicate, includes: includes);

            return _mapper.Map<PedidoDto>(pedido);
        }
    }
}
