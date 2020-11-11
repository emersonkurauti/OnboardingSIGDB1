using OnboardingSIGDB1.Domain.Notifications;

namespace OnboardingSIGDB1.Domain.Interfaces
{
    public interface IGravarService
    {
        NotificationContext notificationContext { get; set; }

        void ValidarEntidade();
        void ValidarExiste();
    }
}
