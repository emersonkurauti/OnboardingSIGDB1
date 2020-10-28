using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class RemoverFuncionarioService : IRemoverFuncionarioService
    {
        public NotificationContext notificationContext { get; set; }
        public int Id { get; set; }

        public bool Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
