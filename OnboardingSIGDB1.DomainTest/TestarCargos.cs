using OnboardingSIGDB1.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnboardingSIGDB1.DomainTest
{
    public class TestarCargos
    {
        [Theory(DisplayName = "TestarCriacaoCurso")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Descrição de cargo com mais de 250 caracteres ................................................................................................................................................................................................................")]
        public void TestarCriacaoCargoDescricaoInvalida(string descricao)
        {
            Cargo cargo = new Cargo();
            cargo.Descricao = descricao;
            Assert.False(cargo.Validar());
        }

        [Fact]
        public void TestarCriacaoCargoDescricaoValida()
        {
            Cargo cargo = new Cargo();
            cargo.Descricao = "Desenvolvedor";
            Assert.True(cargo.Validar());
        }
    }
}
