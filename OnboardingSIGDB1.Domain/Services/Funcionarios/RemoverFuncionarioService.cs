using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class RemoverFuncionarioService : IRemoverFuncionarioService
    {
        public NotificationContext notificationContext { get; set; }

        private readonly IUnitOfWork _unitOfWork;

        public RemoverFuncionarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            notificationContext = new NotificationContext();
        }

        public bool Remover(int id)
        {
            var funcionario = _unitOfWork.FuncionarioRepository.Get(f => f.Id == id);

            if (funcionario == null)
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.FuncionarioRepository.Delete(funcionario);
            var deletou = _unitOfWork.Commit();

            if (!deletou)
                notificationContext.AddNotification(Constantes.sChaveErroRemover, Constantes.sMensagemErroRemover);

            return deletou;
        }
    }
}
