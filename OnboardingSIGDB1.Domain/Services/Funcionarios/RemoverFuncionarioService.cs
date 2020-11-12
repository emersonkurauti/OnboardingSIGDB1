using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class RemoverFuncionarioService : IRemoverFuncionarioService
    {
        public NotificationContext notificationContext { get; set; }

        private readonly IRepository<Funcionario> _funcionarioRepository;

        public RemoverFuncionarioService(IRepository<Funcionario> funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            notificationContext = new NotificationContext();
        }

        public bool Remover(int id)
        {
            var funcionario = _funcionarioRepository.Get(f => f.Id == id);

            if (funcionario == null)
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);

            if (notificationContext.HasNotifications)
                return false;

            _funcionarioRepository.Delete(funcionario);
            return true;
        }
    }
}
