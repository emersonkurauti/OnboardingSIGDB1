using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Interfaces.Empresas;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Utils;
using System.Linq;

namespace OnboardingSIGDB1.Domain.Services.Empresas
{
    public class RemoverEmpresaService : IRemoverEmpresaService
    {
        public NotificationContext notificationContext { get; set; }
        public int Id { get; set; }

        private readonly IUnitOfWork _unitOfWork;

        public RemoverEmpresaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            notificationContext = new NotificationContext();
        }

        public bool Remover(int id)
        {
            var empresa = _unitOfWork.EmpresaRepository.Get(e => e.Id == id);

            if (empresa == null)
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);

            if (_unitOfWork.FuncionarioRepository.GetAll(f => f.EmpresaId == id).Any())
                notificationContext.AddNotification(Constantes.sChaveErroFuncionarioEmpresa, Constantes.sMensagemErroFuncionarioEmpresa);

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.EmpresaRepository.Delete(empresa);
            var deletou = _unitOfWork.Commit();

            if (!deletou)
                notificationContext.AddNotification(Constantes.sChaveErroRemover, Constantes.sMensagemErroRemover);

            return deletou;
        }
    }
}
