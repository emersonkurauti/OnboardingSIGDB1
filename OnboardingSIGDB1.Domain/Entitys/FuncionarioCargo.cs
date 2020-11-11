using OnboardingSIGDB1.Domain.Base;
using System;

namespace OnboardingSIGDB1.Domain.Entitys
{
    public class FuncionarioCargo : EntityValidator<FuncionarioCargo>
    {
        public int CargoId { get; private set; }
        public int FuncionarioId { get; private set; }
        public DateTime DataVinculo { get; private set; }
        public virtual Cargo Cargo { get; private set; }
        public virtual Funcionario Funcionario { get; private set; }

        protected FuncionarioCargo() { }

        public FuncionarioCargo(int cargoId, int funcionarioId, DateTime dataVinculo)
        {
            CargoId = cargoId;
            FuncionarioId = funcionarioId;
            DataVinculo = dataVinculo;
        }

        public void AlterarCargoId(int cargoId)
        {
            CargoId = cargoId;
        }

        public void AlterarFuncionarioId(int funcionarioId)
        {
            FuncionarioId = funcionarioId;
        }

        public void AlterarDataVinculo(DateTime dataVinculo)
        {
            DataVinculo = dataVinculo;
        }

        public override bool Validar()
        {
            return true;
        }
    }
}
