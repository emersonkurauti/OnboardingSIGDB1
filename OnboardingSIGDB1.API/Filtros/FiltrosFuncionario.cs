using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.API.Filtros
{
    /// <summary>
    /// Filtros para consulta da funcionário
    /// </summary>
    public class FiltrosFuncionario : FiltrosBase
    {
        /// <summary>
        /// Cnpj da empresa
        /// </summary>
        public string Cpf { get; set; }
    }
}
