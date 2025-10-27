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
    }
}
