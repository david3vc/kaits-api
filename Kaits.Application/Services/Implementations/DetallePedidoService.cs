using AutoMapper;
using Kaits.Application.Dtos.DetallePedidos;
using Kaits.Domain.Models;
using Kaits.Domain.Repositories;
using System.Linq.Expressions;

namespace Kaits.Application.Services.Implementations
{
    public class DetallePedidoService : IDetallePedidoService
    {
        private readonly IDetallePedidoRepository _detallePedidoRepository;
        private readonly IMapper _mapper;

        public DetallePedidoService(IDetallePedidoRepository detallePedidoRepository, IMapper mapper)
        {
            _detallePedidoRepository = detallePedidoRepository;
            _mapper = mapper;
        }

        public async Task<DetallePedidoDto> CreateAsync(DetallePedidoSaveDto saveDto)
        {
            DetallePedido detallePedido = _mapper.Map<DetallePedido>(saveDto);
            detallePedido.FechaCreacion = DateTime.UtcNow;
            detallePedido.Estado = true;

            await _detallePedidoRepository.SaveAsync(detallePedido);

            return _mapper.Map<DetallePedidoDto>(detallePedido);
        }

        public async Task<DetallePedidoDto> DisabledAsync(int id)
        {
            DetallePedido? detallePedido = await _detallePedidoRepository.FindByIdAsync(id);

            detallePedido.Estado = !detallePedido.Estado;

            await _detallePedidoRepository.SaveAsync(detallePedido);

            return _mapper.Map<DetallePedidoDto>(detallePedido);
        }

        public async Task<DetallePedidoDto> EditAsync(int id, DetallePedidoSaveDto saveDto)
        {
            DetallePedido? detallePedido = await _detallePedidoRepository.FindByIdAsync(id);

            _mapper.Map<DetallePedidoSaveDto, DetallePedido>(saveDto, detallePedido);

            detallePedido.FechaActualizacion = DateTime.UtcNow;

            await _detallePedidoRepository.SaveAsync(detallePedido);

            return _mapper.Map<DetallePedidoDto>(detallePedido);
        }

        public async Task<IReadOnlyList<DetallePedidoDto>> FindAllAsync()
        {
            IReadOnlyList<DetallePedido> detallePedidos = await _detallePedidoRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<DetallePedidoDto>>(detallePedidos);
        }

        public async Task<IReadOnlyList<DetallePedidoDto>> FindAllByIdPedidoAsync(int idPedido)
        {
            List<Expression<Func<DetallePedido, object>>>? includes = new List<Expression<Func<DetallePedido, object>>>()
            {
                t => t.Producto
            };
            Expression<Func<DetallePedido, bool>> predicate = x => x.IdPedido == idPedido;

            IReadOnlyList<DetallePedido> detallePedidos = await _detallePedidoRepository.FindAllAsync(predicate: predicate, includes: includes);

            return _mapper.Map<IReadOnlyList<DetallePedidoDto>>(detallePedidos);
        }

        public async Task<DetallePedidoDto> FindByIdAsync(int id)
        {
            List<Expression<Func<DetallePedido, object>>>? includes = new List<Expression<Func<DetallePedido, object>>>()
            {
                t => t.Producto,
                t => t.Pedido
            };
            Expression<Func<DetallePedido, bool>> predicate = x => x.Id == id;

            DetallePedido? pedido = await _detallePedidoRepository.FindByIdAsync(predicate: predicate, includes: includes);

            return _mapper.Map<DetallePedidoDto>(pedido);
        }
    }
}
