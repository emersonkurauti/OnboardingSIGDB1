﻿using OnboardingSIGDB1.Domain.Dto;

namespace OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo
{
    public interface IGravarFuncionarioCargoService : IGravarService
    {
        bool Adicionar(FuncionarioCargoDTO dto);
    }
}
