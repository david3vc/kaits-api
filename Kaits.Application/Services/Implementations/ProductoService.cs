using AutoMapper;
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

        public async Task<IReadOnlyList<ProductoDto>> FindAllAsync()
        {
            IReadOnlyList<Producto> productos = await _productoRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<ProductoDto>>(productos);
        }

        public async Task<ProductoDto> FindByIdAsync(int id)
        {
            Expression<Func<Producto, bool>> predicate = x => x.Id == id;

            Producto? producto = await _productoRepository.FindByIdAsync(predicate: predicate);

            return _mapper.Map<ProductoDto>(producto);
        }
    }
}
