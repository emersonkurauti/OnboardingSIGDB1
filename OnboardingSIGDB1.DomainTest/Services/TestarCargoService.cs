using Bogus;
using Moq;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Services.Cargos;
using System;
using System.Linq.Expressions;
using Xunit;

namespace OnboardingSIGDB1.DomainTest.Services
{
    public class TestarCargoService
    {
        private CargoDTO _cargoDTO;

        private Mock<IRepository<Cargo>> _cargoRepositoryMock;
        private NotificationContext _notification;
        private GravarCargoService _gravarCargoService;

        public TestarCargoService()
        {
            var fake = new Faker();
            _cargoDTO = new CargoDTO
            {
                Descricao = fake.Random.Words(2)
            };

            _cargoRepositoryMock = new Mock<IRepository<Cargo>>();
            _notification = new NotificationContext();
            _gravarCargoService = new GravarCargoService(_cargoRepositoryMock.Object, _notification);
        }

        [Fact]
        public void TestarDeveAddCargo()
        {
            _gravarCargoService.Adicionar(_cargoDTO);

            _cargoRepositoryMock.Verify(m => m.Add(
                It.Is<Cargo>(c => c.Descricao == _cargoDTO.Descricao)
            ));
        }

        [Fact]
        public void TestarNaoDeveAddCargoMesmaDescricaoDeOutroJaSalvo()
        {
            _cargoRepositoryMock.Setup(r => r.Exist(It.IsAny<Expression<Func<Cargo, bool>>>())).Returns(true);

            _gravarCargoService.Adicionar(_cargoDTO);

            _cargoRepositoryMock.Verify(m => m.Add(
                It.Is<Cargo>(c => c.Descricao == _cargoDTO.Descricao)
            ), Times.Never());
        }
    }
}
