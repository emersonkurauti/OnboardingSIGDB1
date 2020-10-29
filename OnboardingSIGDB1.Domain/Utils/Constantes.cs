using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Utils
{
    public static class Constantes
    {
        public const string sChaveErroInclusao = "ErroAdicionar";
        public const string sMensagemErroInclusao = "Não foi possível realizar a inclusão.";
        public const string sChaveErroAlteracao = "ErroAlterar";
        public const string sMensagemErroAlteracao = "Não foi possível realizar a alteração.";
        public const string sChaveErroLocalizar = "ErroNaoLocalizado";
        public const string sMensagemErroLocalizar = "Registro não localizado.";
        public const string sChaveErroRemover = "ErroRemover";
        public const string sMensagemErroRemover = "Não foi possível realizar a remoção.";
        public const string sChaveErroMesmoCPF = "ErroExisteCPF";
        public const string sMensagemErroMesmoCPF = "CPF já incluído na base.";
        public const string sChaveErroMesmoCNPJ = "ErroExisteCNPJ";
        public const string sMensagemErroMesmoCNPJ = "CNPJ já incluído na base.";
        public const string sChaveErroCPFInvalido = "ErroCPFInvalido";
        public const string sMensagemErroCPFInvalido = "CPF inválido.";
        public const string sChaveErroCNPJInvalido = "ErroCNPJInvalido";
        public const string sMensagemErroCNPJInvalido = "CNPJ inválido.";
    }
}
