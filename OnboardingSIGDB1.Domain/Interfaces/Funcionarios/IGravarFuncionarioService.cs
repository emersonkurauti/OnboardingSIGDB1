﻿using OnboardingSIGDB1.Domain.Dto;

namespace OnboardingSIGDB1.Domain.Interfaces.Funcionarios
{
    public interface IGravarFuncionarioService : IGravarService
    {
        bool Adicionar(ref FuncionarioDTO dto);
        bool Alterar(int id, FuncionarioDTO dto);
        bool VincularEmpresa(int id, FuncionarioEmpresaDTO dto);
    }
}
