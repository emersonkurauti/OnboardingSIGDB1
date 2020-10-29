﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.API.Filtros
{
    /// <summary>
    /// Filtros para consulta da empresa
    /// </summary>
    public class FiltrosEmpresa : FiltrosBase
    {
        /// <summary>
        /// Cnpj da empresa
        /// </summary>
        public string Cnpj { get; set; }
    }
}
