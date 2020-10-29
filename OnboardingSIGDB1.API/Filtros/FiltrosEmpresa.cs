using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.API.Filtros
{
    /// <summary>
    /// Filtros para consulta da empresa
    /// </summary>
    public class FiltrosEmpresa
    {
        /// <summary>
        /// Nome da empresa
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Cnpj da empresa
        /// </summary>
        public string Cnpj { get; set; }
        /// <summary>
        /// Data de ínicio para filtro
        /// </summary>
        public DateTime? dtInicio { get; set; }
        /// <summary>
        /// Data de fim para o filtro
        /// </summary>
        public DateTime? dfFim { get; set; }
    }
}
