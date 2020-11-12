using OnboardingSIGDB1.Domain.Notifications;

namespace OnboardingSIGDB1.Domain.Interfaces
{
    public interface IRemoverService
    {
        INotificationContext notificationContext { get; set; }
        bool Remover(int id);
    }
}
