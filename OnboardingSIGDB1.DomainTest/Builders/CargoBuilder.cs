using Bogus;
using OnboardingSIGDB1.Domain.Entitys;

namespace OnboardingSIGDB1.DomainTest.Builders
{
    public class CargoBuilder
    {
        private string _descricao;

        public static CargoBuilder Novo()
        {
            var fake = new Faker();
            var cargoBuilder = new CargoBuilder();
            cargoBuilder.ComDescricao(fake.Random.Words(2));
            return cargoBuilder;
        }

        public Cargo Build()
        {
            return new Cargo(_descricao);
        }

        public CargoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }
    }
}
