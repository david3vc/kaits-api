using AutoFixture;
using AutoMapper;
using Kaits.Application.Dtos.Clientes.Profiles;
using Kaits.Application.Dtos.DetallePedidos;
using Kaits.Application.Dtos.DetallePedidos.Profiles;
using Kaits.Application.Dtos.Pedidos.Profiles;
using Kaits.Application.Dtos.Productos.Profiles;
using Kaits.Application.Services;
using Kaits.Application.Services.Implementations;
using Kaits.Domain.Models;
using Kaits.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Kaits.UnitTest.Application.Services
{
    public class DetalleDetallePedidoServiceTest
    {
        Mock<IDetallePedidoRepository> _mockDetallePedidoRepository;
        Mock<ILogger<DetallePedidoService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public DetalleDetallePedidoServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<DetallePedidoProfile>();
                c.AddProfile<ClienteProfile>();
                c.AddProfile<PedidoProfile>();
                c.AddProfile<ProductoProfile>();
            });
            _mapper = mapperConfiguration.CreateMapper();
            _mockDetallePedidoRepository = new Mock<IDetallePedidoRepository>();
            _mockILogger = new Mock<ILogger<DetallePedidoService>>();
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async void returnDetallePedidosDtoWhenFindAllAsync()
        {
            // Arrange
            IReadOnlyList<DetallePedido> detallePedido = _fixture.CreateMany<DetallePedido>(5)
                .ToList();

            _mockDetallePedidoRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(detallePedido);

            // Act
            IDetallePedidoService detallePedidoService = new DetallePedidoService(_mockDetallePedidoRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<DetallePedidoDto> detallePedidoDtos = await detallePedidoService.FindAllAsync();

            // Assert
            Assert.Equal(detallePedido.Count, detallePedidoDtos.Count);
        }

        [Fact]
        public async void returnDetallePedidosDtoWhenCreateAsync()
        {
            // Arrage

            DetallePedido detallePedido = new()
            {
                Id = 1,
                IdPedido = 1,
                Cantidad = 3,
                IdProducto = 1,
                Subtotal = 5,
                FechaCreacion = DateTime.Now,
                FechaActualizacion = null,
                Estado = true
            };

            _mockDetallePedidoRepository
                .Setup(r => r.SaveAsync(It.IsAny<DetallePedido>()))
                .ReturnsAsync(detallePedido);

            // Act

            DetallePedidoSaveDto detallePedidoSaveDto = new()
            {
                IdPedido = detallePedido.IdPedido,
                IdProducto = detallePedido.IdProducto,
                Subtotal = detallePedido.Subtotal,
                Cantidad = detallePedido.Cantidad
            };

            IDetallePedidoService detallePedidoService = new DetallePedidoService(_mockDetallePedidoRepository.Object, _mapper, _mockILogger.Object);

            DetallePedidoDto detallePedidoDto = await detallePedidoService.CreateAsync(detallePedidoSaveDto);

            // Assert

            Assert.Equal(detallePedido.Cantidad, detallePedidoDto.Cantidad);
        }
    }
}
