using OnboardingSIGDB1.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Entitys
{
    public class FuncionarioCargo : EntityValidator<FuncionarioCargo>
    {
        public int CargoId { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime DataVinculo { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        public override bool Validar()
        {
            return true;
        }
    }
}
