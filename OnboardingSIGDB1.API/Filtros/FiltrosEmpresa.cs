using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.API.Filtros
{
    public class FiltrosEmpresa
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime? dtInicio { get; set; }
        public DateTime? dfFim { get; set; }
    }
}
