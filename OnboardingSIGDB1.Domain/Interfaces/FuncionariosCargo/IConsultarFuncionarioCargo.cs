using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo
{
    public interface IConsultarFuncionarioCargo
    {
        bool VerificarExisteVinculo(int cargoId);
    }
}
