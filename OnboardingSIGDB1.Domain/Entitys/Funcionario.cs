using FluentValidation;
using OnboardingSIGDB1.Domain.Base;
using System;

namespace OnboardingSIGDB1.Domain.Entitys
{
    public class Funcionario : EntityValidator<int, Funcionario>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataContratacao { get; set; }
        public int CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        public override bool Validar()
        {
            RuleFor(f => f.Nome).NotEmpty().NotNull().MaximumLength(150);
            RuleFor(f => f.Cpf).NotEmpty().NotNull().MaximumLength(11);
            RuleFor(f => f.DataContratacao).GreaterThan(DateTime.MinValue);

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
