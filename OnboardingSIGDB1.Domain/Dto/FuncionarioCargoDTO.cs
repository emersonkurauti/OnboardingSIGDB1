using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Dto
{
    public class FuncionarioCargoDTO
    {
        public int CargoId { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime DataVinculo { get; set; }
    }
}
