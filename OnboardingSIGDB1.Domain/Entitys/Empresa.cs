using FluentValidation;
using OnboardingSIGDB1.Domain.Base;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace OnboardingSIGDB1.Domain.Entitys
{
    public class Empresa : EntityValidator<Empresa>
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime? DataFundacao { get; private set; }
        public virtual IEnumerable<Funcionario> Funcionarios { get; private set; }

        protected Empresa() { }

        public Empresa(string nome, string cnpj)
        {
            Nome = nome?.Trim();
            Cnpj = cnpj?.Trim();
        }

        public void AlterarNome(string nome)
        {
            Nome = nome?.Trim();
        }

        public void AlterarCnpj(string cnpj)
        {
            Cnpj = cnpj?.Trim();
        }

        public void AlterarDataFundacao(DateTime? dataFundacao)
        {
            DataFundacao = dataFundacao;
        }

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
