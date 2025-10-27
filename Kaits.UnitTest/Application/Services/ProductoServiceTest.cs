using AutoFixture;
using AutoMapper;
using Kaits.Application.Dtos.Productos;
using Kaits.Application.Dtos.Productos.Profiles;
using Kaits.Application.Services;
using Kaits.Application.Services.Implementations;
using Kaits.Domain.Models;
using Kaits.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Kaits.UnitTest.Application.Services
{
    public class ProductoServiceTest
    {
        Mock<IProductoRepository> _mockProductoRepository;
        Mock<ILogger<ProductoService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public ProductoServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<ProductoProfile>();
            });
            _mapper = mapperConfiguration.CreateMapper();
            _mockProductoRepository = new Mock<IProductoRepository>();
            _mockILogger = new Mock<ILogger<ProductoService>>();
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        //Task<IReadOnlyList<TDto>> FindAllAsync();
        //Task<TDto> FindByIdAsync(ID id);
        //Task<PageResponse<TDto>> FindAllPaginatedAsync(PageRequest<TDtoFilter> request);

        [Fact]
        public async void returnProductoDtoWhenFindByIdAsync()
        {
            // Arrange


            Producto producto = _fixture.Create<Producto>();

            _mockProductoRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(producto);

            // Act
            IProductoService productoService = new ProductoService(_mockProductoRepository.Object, _mapper, _mockILogger.Object);

            ProductoDto productoDto = await productoService.FindByIdAsync(producto.Id);

            // Assert
            Assert.Equal(producto.Descripcion, productoDto.Descripcion);
        }

        [Fact]
        public async void returnProductosDtoWhenFindAllAsync()
        {
            // Arrange
            IReadOnlyList<Producto> productos = _fixture.CreateMany<Producto>(5)
                .ToList();

            _mockProductoRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(productos);

            // Act
            IProductoService productoService = new ProductoService(_mockProductoRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<ProductoDto> productoDtos = await productoService.FindAllAsync();

            // Assert
            Assert.Equal(productos.Count, productoDtos.Count);
        }
    }

}
