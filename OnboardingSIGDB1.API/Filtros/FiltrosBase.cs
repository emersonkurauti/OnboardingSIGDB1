using System;

namespace OnboardingSIGDB1.API.Filtros
{
    /// <summary>
    /// Filtros Base
    /// </summary>
    public class FiltrosBase
    {
        /// <summary>
        /// Nome da empresa
        /// </summary>
        public string Nome { get; set; }
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
