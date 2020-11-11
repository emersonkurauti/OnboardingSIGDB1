using FluentValidation;
using OnboardingSIGDB1.Domain.Base;
using System.Collections.Generic;

namespace OnboardingSIGDB1.Domain.Entitys
{
    public class Cargo : EntityValidator<Cargo>
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public virtual IEnumerable<FuncionarioCargo> FuncionarioCargo { get; private set; }

        protected Cargo() { }

        public Cargo(string descricao)
        {
            Descricao = descricao?.Trim();
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao?.Trim();
        }

        public override bool Validar()
        {
            RuleFor(c => c.Descricao).NotEmpty().NotNull().MaximumLength(250);

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
