using AutoMapper;
using Kaits.Application.Cores.Exceptions;
using Kaits.Application.Dtos.Pedidos;
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
