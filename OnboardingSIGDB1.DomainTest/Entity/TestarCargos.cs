using OnboardingSIGDB1.Domain.Entitys;
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
            Cargo cargo = new Cargo(descricao);
            Assert.False(cargo.Validar());
        }

        [Fact]
        public void TestarCriacaoCargoDescricaoValida()
        {
            Cargo cargo = new Cargo("Desenvolvedor");
            Assert.True(cargo.Validar());
        }
    }
}
