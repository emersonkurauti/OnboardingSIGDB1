using OnboardingSIGDB1.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Interfaces.Empresas
{
    public interface IRemoverEmpresaService
    {
        NotificationContext notificationContext { get; set; }
        int Id { get; set; }
        bool Remover(int id);
    }
}
