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
        public const string sChaveErroEmpresaVinculada = "ErroEmpresaVinculada";
        public const string sMensagemErroEmpresaVinculada = "Funcionário já possui empresa vinculada.";
        public const string sChaveErroEmpresaNaoLocalizadaParaVincular = "ErroEmpresaNaoLocalizadaVinculo";
        public const string sMensagemErroEmpresaNaoLocalizadaParaVincular = "Empresa não localizada para vincular.";
        public const string sChaveErroFuncionarioSemEmpresa = "ErroFuncionarioSemEmpresa";
        public const string sMensagemErroFuncionarioSemEmpresa = "Funcionáio não está vinculado com uma empresa.";
        public const string sChaveErrooFuncionarioCargo = "ErroFuncionarioCargo";
        public const string sMensagemErrooFuncionarioCargo = "Funcionário já vinculado ao cargo.";
        public const string sChaveErroCargoFuncionario = "ErroCargoVinculoFuncionario";
        public const string sMensagemErroCargoFuncionario = "Cargo possui fuincionários vinculados.";
    }
}
