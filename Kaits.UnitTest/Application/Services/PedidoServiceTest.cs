using AutoFixture;
using AutoMapper;
using Kaits.Application.Dtos.Clientes.Profiles;
using Kaits.Application.Dtos.DetallePedidos.Profiles;
using Kaits.Application.Dtos.Pedidos;
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
    public class PedidoServiceTest
    {
        Mock<IPedidoRepository> _mockPedidoRepository;
        Mock<IDetallePedidoService> _mockDetallePedidoService;
        Mock<ILogger<PedidoService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public PedidoServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<PedidoProfile>();
                c.AddProfile<ClienteProfile>();
                c.AddProfile<DetallePedidoProfile>();
                c.AddProfile<ProductoProfile>();
            });
            _mapper = mapperConfiguration.CreateMapper();
            _mockPedidoRepository = new Mock<IPedidoRepository>();
            _mockDetallePedidoService = new Mock<IDetallePedidoService>();
            _mockILogger = new Mock<ILogger<PedidoService>>();
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async void returnPedidosDtoWhenFindAllAsync()
        {
            // Arrange
            IReadOnlyList<Pedido> pedidos = _fixture.CreateMany<Pedido>(5)
                .ToList();

            _mockPedidoRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(pedidos);

            // Act
            IPedidoService pedidoService = new PedidoService(_mockPedidoRepository.Object, _mapper, _mockDetallePedidoService.Object, _mockILogger.Object);

            IReadOnlyList<PedidoDto> pedidoDtos = await pedidoService.FindAllAsync();

            // Assert
            Assert.Equal(pedidos.Count, pedidoDtos.Count);
        }
    }
}
