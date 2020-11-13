using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.DomainTest.Builders;
using Xunit;

namespace OnboardingSIGDB1.DomainTest.Entity
{
    public class TestarCargos
    {
        [Theory(DisplayName = "TestarCriacaoCurso")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Descrição de cargo com mais de 250 caracteres ................................................................................................................................................................................................................")]
        public void TestarCriacaoCargoDescricaoInvalida(string descricao)
        {
            Cargo cargo = CargoBuilder.Novo().ComDescricao(descricao).Build();
            Assert.False(cargo.Validar());
        }

        [Fact]
        public void TestarCriacaoCargoDescricaoValida()
        {
            Cargo cargo = CargoBuilder.Novo().Build();
            Assert.True(cargo.Validar());
        }
    }
}
