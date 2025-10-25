using AutoMapper;
using Kaits.Application.Cores.Exceptions;
using Kaits.Application.Dtos.Productos;
using Kaits.Domain.Models;
using Kaits.Domain.Repositories;
using System.Linq.Expressions;

namespace Kaits.Application.Services.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductoDto>> FindAllAsync()
        {
            IReadOnlyList<Producto> productos = await _productoRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<ProductoDto>>(productos);
        }

        public async Task<ProductoDto> FindByIdAsync(int id)
        {
            Expression<Func<Producto, bool>> predicate = x => x.Id == id;

            Producto? producto = await _productoRepository.FindByIdAsync(predicate: predicate);

            if (producto is null) throw ProductoNotFound(id);

            return _mapper.Map<ProductoDto>(producto);
        }

        private NotFoundCoreException ProductoNotFound(int id)
        {
            return new NotFoundCoreException("Producto no encontrado para el id: " + id);
        }
    }
}
