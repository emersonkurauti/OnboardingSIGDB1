using OnboardingSIGDB1.Domain.Utils;
using Xunit;

namespace OnboardingSIGDB1.DomainTest.Utils
{
    public class TestarValidadoresDocumentos
    {

        [Fact(DisplayName = "TestarValidadorCPFValido")]
        public void TestarValidadorCPFValido()
        {
            var cpf = "33214080822";

            Assert.True(ValidadorCPF.ValidaCPF(cpf));
        }


        [Fact(DisplayName = "TestarValidadorCPFInvalido")]
        public void TestarValidadorCPFInvalido()
        {
            var cpf = "33210080822";

            Assert.False(ValidadorCPF.ValidaCPF(cpf));
        }

        [Fact(DisplayName = "TestarValidadorCNPJValido")]
        public void TestarValidadorCNPJValido()
        {
            var cnpj = "92349340000140";

            Assert.True(ValidadorCPNJ.ValidaCNPJ(cnpj));
        }


        [Fact(DisplayName = "TestarValidadorCNPJInvalido")]
        public void TestarValidadorCNPJInvalido()
        {
            var cnpj = "92349340000100";

            Assert.False(ValidadorCPNJ.ValidaCNPJ(cnpj));
        }
    }
}
