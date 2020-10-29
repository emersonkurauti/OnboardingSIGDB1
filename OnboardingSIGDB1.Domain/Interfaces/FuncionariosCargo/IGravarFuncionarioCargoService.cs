using OnboardingSIGDB1.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo
{
    public interface IGravarFuncionarioCargoService : IGravarService
    {
        void ValidarEmpresaVinculada(int id);
        void ValidarExiste(int cargoId, int funcionarioId);
        bool Adicionar(FuncionarioCargoDTO dto);
    }
}
