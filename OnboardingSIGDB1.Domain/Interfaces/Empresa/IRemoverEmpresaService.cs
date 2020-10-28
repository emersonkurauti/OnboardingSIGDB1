using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Domain.Interfaces
{
    public interface IRemoverService
    {
        NotificationContext notificationContext { get; set; }
        int Id { get; set; }
        bool Remover(int id);
    }
}
