using FluentValidation;
using OnboardingSIGDB1.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Entitys
{
    public class Cargo : EntityValidator<int, Cargo>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public override bool Validar()
        {
            RuleFor(c => c.Descricao).NotEmpty().NotNull().MaximumLength(250);

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
