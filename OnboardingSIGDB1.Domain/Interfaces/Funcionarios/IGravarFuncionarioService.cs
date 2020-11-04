using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Interfaces.Funcionarios
{
    public interface IGravarFuncionarioService : IGravarService
    {
        void ValidarExisteMesmoCPF(string cpf);
        void ValidarCPF(string cpf);
        void ValidarEmpresaVinculada(int id);
        void ValidarEmpresaExiste(int id);
        bool Adicionar(FuncionarioDTO dto);
        bool Alterar(int id, FuncionarioDTO dto);
        bool VincularEmpresa(int id, FuncionarioEmpresaDTO dto);
    }
}
