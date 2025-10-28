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

        [Fact]
        public async void returnPedidosDtoWhenCreateAsync()
        {
            // Arrage

            Pedido pedido = new()
            {
                Id = 1,
                Fecha = DateTime.Now,
                IdCliente = 3,
                Total = 14,
                FechaCreacion = DateTime.Now,
                FechaActualizacion = null,
                Estado = true
            };

            _mockPedidoRepository
                .Setup(r => r.SaveAsync(It.IsAny<Pedido>()))
                .ReturnsAsync(pedido);

            // Act

            PedidoSaveDto pedidoSaveDto = new()
            {
                Fecha = pedido.Fecha,
                IdCliente = pedido.IdCliente,
                Total = pedido.Total
            };

            IPedidoService pedidoService = new PedidoService(_mockPedidoRepository.Object, _mapper, _mockDetallePedidoService.Object, _mockILogger.Object);

            PedidoDto pedidoDto = await pedidoService.CreateAsync(pedidoSaveDto);

            // Assert

            Assert.Equal(pedido.IdCliente, pedidoDto.IdCliente);
        }

        [Fact]
        public async void returnPedidosDtoWhenEditAsync()
        {
            // Arrage
            int id = 1;
            Pedido pedido = new()
            {
                Id = 1,
                Fecha = DateTime.Now,
                IdCliente = 3,
                Total = 14,
                FechaCreacion = DateTime.Now,
                FechaActualizacion = null,
                Estado = true
            };
            _mockPedidoRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(pedido);

            _mockPedidoRepository
                .Setup(r => r.SaveAsync(It.IsAny<Pedido>()))
                .ReturnsAsync(pedido);


            // Act

            PedidoSaveDto pedidoSaveDto = new()
            {
                Fecha = pedido.Fecha,
                IdCliente = pedido.IdCliente,
                Total = pedido.Total
            };

            IPedidoService pedidoService = new PedidoService(_mockPedidoRepository.Object, _mapper, _mockDetallePedidoService.Object, _mockILogger.Object);

            PedidoDto pedidoDto = await pedidoService.EditAsync(id, pedidoSaveDto);

            // Assert

            Assert.Equal(pedido.IdCliente, pedidoDto.IdCliente);
        }

        [Fact]
        public async void returnPedidosDtoWhenDisabledAsync()
        {
            // Arrage
            int id = 1;
            Pedido pedido = new()
            {
                Id = 1,
                Fecha = DateTime.Now,
                IdCliente = 3,
                Total = 14,
                FechaCreacion = DateTime.Now,
                FechaActualizacion = null,
                Estado = true
            };
            _mockPedidoRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(pedido);

            _mockPedidoRepository
                .Setup(r => r.SaveAsync(It.IsAny<Pedido>()))
                .ReturnsAsync(pedido);


            // Act

            IPedidoService pedidoService = new PedidoService(_mockPedidoRepository.Object, _mapper, _mockDetallePedidoService.Object, _mockILogger.Object);

            PedidoDto pedidoDto = await pedidoService.DisabledAsync(id);

            // Assert

            Assert.Equal(pedido.IdCliente, pedidoDto.IdCliente);
        }
    }
}
