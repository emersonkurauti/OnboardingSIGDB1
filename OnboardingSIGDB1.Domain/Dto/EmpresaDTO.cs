using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Dto
{
    public class EmpresaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime? DataFundacao { get; set; }
    }
}
