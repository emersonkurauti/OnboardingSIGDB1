using OnboardingSIGDB1.Domain.Notifications;

namespace OnboardingSIGDB1.Domain.Interfaces
{
    public interface IRemoverService
    {
        NotificationContext notificationContext { get; set; }
        int Id { get; set; }
        bool Remover(int id);
    }
}
