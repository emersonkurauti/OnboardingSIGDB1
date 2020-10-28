using FluentValidation;
using OnboardingSIGDB1.Domain.Base;
using System;
using System.Collections.Generic;

namespace OnboardingSIGDB1.Domain.Entitys
{
    public class Empresa : EntityValidator<Empresa>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime? DataFundacao { get; set; }
        public virtual IEnumerable<Funcionario> Funcionarios { get; set; }

        public override bool Validar()
        {
            RuleFor(e => e.Nome).NotEmpty().NotNull().MaximumLength(150);
            RuleFor(e => e.Cnpj).NotEmpty().NotNull().MaximumLength(14);
            RuleFor(e => e.DataFundacao).GreaterThan(DateTime.MinValue);

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
