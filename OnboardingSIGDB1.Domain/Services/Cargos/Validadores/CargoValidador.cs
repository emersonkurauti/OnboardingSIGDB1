using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Cargos.Validadores
{
    public class CargoValidador : ValidadorBase<Cargo>
    {
        public CargoValidador(NotificationContext notification, Cargo cargo) 
        {
            notificationContext = notification;
            entidade = cargo;
        }

        public void ValidarInclusao()
        {
            ValidarEntidade();
        }

        public void ValidarAlteracao()
        {
            ValidarExiste();
            ValidarEntidade();
        }

        private void ValidarEntidade()
        {
            if (entidade != null && !entidade.Validar())
                notificationContext.AddNotifications(entidade.ValidationResult);
        }

        private void ValidarExiste()
        {
            if (entidade == null)
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);
        }
    }
}
