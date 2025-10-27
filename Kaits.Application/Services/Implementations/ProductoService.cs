using AutoMapper;
using Kaits.Application.Cores.Dtos;
using Kaits.Application.Cores.Exceptions;
using Kaits.Application.Dtos.Productos;
using Kaits.Domain.Cores.Models;
using Kaits.Domain.Models;
using Kaits.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Kaits.Application.Services.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly ILogger<ProductoService> _logger;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository productoRepository, IMapper mapper, ILogger<ProductoService> logger)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IReadOnlyList<ProductoDto>> FindAllAsync()
        {
            IReadOnlyList<Producto> productos = await _productoRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<ProductoDto>>(productos);
        }

        public async Task<PageResponse<ProductoDto>> FindAllPaginatedAsync(PageRequest<ProductoFilterDto> request)
        {
            var filter = request.Filter ?? new ProductoFilterDto();
            var paging = new Paging() { PageNumber = request.Page, PageSize = request.PerPage };

            Expression<Func<Producto, bool>> predicate = x =>
                (string.IsNullOrWhiteSpace(filter.Descripcion) || x.Descripcion.ToUpper().Contains(filter.Descripcion.ToUpper()))
                && (!filter.Estado.HasValue || x.Estado == filter.Estado)
                && (!filter.PrecioUnitario.HasValue || x.PrecioUnitario == filter.PrecioUnitario);

            var response = await _productoRepository.FindAllPaginatedAsync(paging: paging, predicate: predicate);

            return _mapper.Map<PageResponse<ProductoDto>>(response);
        }

        public async Task<ProductoDto> FindByIdAsync(int id)
        {
            Producto? producto = await _productoRepository.FindByIdAsync(id);

            if (producto is null)
            {
                _logger.LogWarning("Producto no encontrado para el id: " + id);
                throw ProductoNotFound(id);
            }

            return _mapper.Map<ProductoDto>(producto);
        }

        private NotFoundCoreException ProductoNotFound(int id)
        {
            return new NotFoundCoreException("Producto no encontrado para el id: " + id);
        }
    }
}
