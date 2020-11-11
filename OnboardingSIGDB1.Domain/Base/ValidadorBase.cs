using OnboardingSIGDB1.Domain.Notifications;

namespace OnboardingSIGDB1.Domain.Base
{
    public class ValidadorBase<TEntity> where TEntity : class
    {
        public NotificationContext notificationContext { get; set; }
        public TEntity entidade { get; set; }
    }
}
