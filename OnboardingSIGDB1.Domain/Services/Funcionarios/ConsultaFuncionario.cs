using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using System.Linq;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class ConsultaFuncionario : IConsultaFuncionario
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public ConsultaFuncionario(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public bool VerificarEmrpesaVinculada(int empresaId)
        {
            return _funcionarioRepository.GetAll(f => f.EmpresaId == empresaId).Any();
        }
    }
}
