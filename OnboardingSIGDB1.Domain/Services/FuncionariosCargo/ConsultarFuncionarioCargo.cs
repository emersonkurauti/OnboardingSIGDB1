using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo;
using System.Linq;

namespace OnboardingSIGDB1.Domain.Services.FuncionariosCargos
{
    public class ConsultarFuncionarioCargo : IConsultarFuncionarioCargo
    {
        private readonly IRepository<FuncionarioCargo> _funcionarioCargoRepository;

        public ConsultarFuncionarioCargo(IRepository<FuncionarioCargo> funcionarioCargoRepository)
        {
            _funcionarioCargoRepository = funcionarioCargoRepository;
        }

        public bool VerificarExisteVinculo(int cargoId)
        {
            return _funcionarioCargoRepository.GetAll(fc => fc.CargoId == cargoId).Any();
        }
    }
}
