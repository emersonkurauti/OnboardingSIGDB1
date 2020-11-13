using Bogus;
using Moq;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Services.Cargos;
using Xunit;

namespace OnboardingSIGDB1.DomainTest.Services
{
    public class TestarCargoService
    {
        private CargoDTO _cargoDTO;

        private Mock<IRepository<Cargo>> _cargoRepositoryMock;
        private Mock<INotificationContext> _notificationMock;
        private GravarCargoService _gravarCargoService;

        public TestarCargoService()
        {
            var fake = new Faker();
            _cargoDTO = new CargoDTO
            {
                Descricao = fake.Random.Words(2)
            };

            _cargoRepositoryMock = new Mock<IRepository<Cargo>>();
            _notificationMock = new Mock<INotificationContext>();
            _gravarCargoService = new GravarCargoService(_cargoRepositoryMock.Object, _notificationMock.Object);
        }

        [Fact]
        public void TestarAddCargo()
        {
            _gravarCargoService.Adicionar(_cargoDTO);

            _cargoRepositoryMock.Verify(m => m.Add(
                It.Is<Cargo>(c => c.Descricao == _cargoDTO.Descricao)
            ));
        }
    }
}
