using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Interfaces.Funcionarios
{
    public interface IConsultaFuncionario
    {
        bool VerificarEmrpesaVinculada(int empresaId);
    }
}
