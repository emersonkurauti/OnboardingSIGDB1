using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.FuncionariosCargo.Validadores
{
    public class FuncionarioCargoValidador: ValidadorBase<FuncionarioCargo>
    {
        private IRepository<FuncionarioCargo> _funcionarioCargoRepository;
        private IFuncionarioRepository _funcionarioRepository;

        public FuncionarioCargoValidador(INotificationContext notification, FuncionarioCargo funcionarioCargo, 
            IRepository<FuncionarioCargo> funcionarioCargoRepository,
            IFuncionarioRepository funcionarioRepository)
        {
            notificationContext = notification;
            entidade = funcionarioCargo;
            _funcionarioCargoRepository = funcionarioCargoRepository;
            _funcionarioRepository = funcionarioRepository;
        }

        public void ValidarVinculoFuncionarioCargo()
        {
            ValidarEmpresaVinculada();
            ValidarExiste();
            ValidarEntidade();
        }

        private void ValidarEmpresaVinculada()
        {
            var funcionario = _funcionarioRepository.Get(f => f.Id == entidade.FuncionarioId);

            if (funcionario.EmpresaId == null)
                notificationContext.AddNotification(Constantes.sChaveErroFuncionarioSemEmpresa, Constantes.sMensagemErroFuncionarioSemEmpresa);
        }

        private void ValidarEntidade()
        {
            if (!entidade.Validar())
                notificationContext.AddNotifications(entidade.ValidationResult);
        }

        private void ValidarExiste()
        {
            if (_funcionarioCargoRepository.Exist(fc => fc.CargoId == entidade.CargoId && fc.FuncionarioId == entidade.FuncionarioId))
                notificationContext.AddNotification(Constantes.sChaveErrooFuncionarioCargo, Constantes.sMensagemErrooFuncionarioCargo);
        }
    }
}
