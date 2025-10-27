using AutoFixture;
using AutoMapper;
using Kaits.Application.Dtos.Clientes;
using Kaits.Application.Dtos.Clientes.Profiles;
using Kaits.Application.Services;
using Kaits.Application.Services.Implementations;
using Kaits.Domain.Models;
using Kaits.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Kaits.UnitTest.Application.Services
{
    public class ClienteServiceTest
    {
        Mock<IClienteRepository> _mockClienteRepository;
        Mock<ILogger<ClienteService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public ClienteServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<ClienteProfile>();
            });
            _mapper = mapperConfiguration.CreateMapper();
            _mockClienteRepository = new Mock<IClienteRepository>();
            _mockILogger = new Mock<ILogger<ClienteService>>();
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async void returnClienteDtoWhenFindByIdAsync()
        {
            // Arrange
            Cliente cliente = _fixture.Create<Cliente>();

            _mockClienteRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(cliente);

            // Act
            IClienteService clienteService = new ClienteService(_mockClienteRepository.Object, _mapper, _mockILogger.Object);

            ClienteDto clienteDto = await clienteService.FindByIdAsync(cliente.Id);

            // Assert
            Assert.Equal(cliente.Dni, clienteDto.Dni);
        }

        [Fact]
        public async void returnClientesDtoWhenFindAllAsync()
        {
            // Arrange
            IReadOnlyList<Cliente> clientes = _fixture.CreateMany<Cliente>(5)
                .ToList();

            _mockClienteRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(clientes);

            // Act
            IClienteService clienteService = new ClienteService(_mockClienteRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<ClienteDto> clienteDtos = await clienteService.FindAllAsync();

            // Assert
            Assert.Equal(clientes.Count, clienteDtos.Count);
        }
    }
}
