using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.FuncionariosCargo.Validador
{
    public class FuncionarioCargoValidador: ValidadorBase<FuncionarioCargo>
    {
        private IUnitOfWork _unitOfWork;

        public FuncionarioCargoValidador(NotificationContext notification, FuncionarioCargo funcionarioCargo, IUnitOfWork unitOfWork)
        {
            notificationContext = notification;
            entidade = funcionarioCargo;
            _unitOfWork = unitOfWork;
        }

        public void ValidarVinculoFuncionarioCargo()
        {
            ValidarEmpresaVinculada();
            ValidarExiste();
            ValidarEntidade();
        }

        private void ValidarEmpresaVinculada()
        {
            var funcionario = _unitOfWork.FuncionarioRepository.Get(f => f.Id == entidade.FuncionarioId);

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
            if (_unitOfWork.FuncionarioCargoRepository.Exist(fc => fc.CargoId == entidade.CargoId && fc.FuncionarioId == entidade.FuncionarioId))
                notificationContext.AddNotification(Constantes.sChaveErrooFuncionarioCargo, Constantes.sMensagemErrooFuncionarioCargo);
        }
    }
}
