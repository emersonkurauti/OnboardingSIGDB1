using FluentValidation;
using OnboardingSIGDB1.Domain.Base;
using System;
using System.Collections.Generic;

namespace OnboardingSIGDB1.Domain.Entitys
{
    public class Funcionario : EntityValidator<Funcionario>
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime? DataContratacao { get; private set; }
        public int? EmpresaId { get; private set; }
        public virtual Empresa Empresa { get; private set; }
        public virtual IEnumerable<FuncionarioCargo> FuncionarioCargo { get; private set; }

        protected Funcionario() { }

        public Funcionario(string nome, string cpf)
        {
            Nome = nome?.Trim();
            Cpf = cpf?.Trim();
        }

        public void AlterarNome(string nome)
        {
            Nome = nome?.Trim();
        }

        public void AlterarCpf(string cpf)
        {
            Cpf = cpf?.Trim();
        }

        public void AlterarDataContratacao(DateTime? dataContratacao)
        {
            DataContratacao = dataContratacao;
        }

        public void AlterarEmpresaId(int empresaId)
        {
            EmpresaId = empresaId;
        }

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
