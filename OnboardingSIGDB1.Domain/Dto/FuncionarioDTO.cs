using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Dto
{
    public class FuncionarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataContratacao { get; set; }
        public int CargoId { get; set; }
        public int EmpresaId { get; set; }
    }
}
