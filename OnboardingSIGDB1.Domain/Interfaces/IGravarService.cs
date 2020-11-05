using OnboardingSIGDB1.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Interfaces
{
    public interface IGravarService
    {
        NotificationContext notificationContext { get; set; }

        void ValidarEntidade();
        void ValidarExiste(int id);
    }
}
