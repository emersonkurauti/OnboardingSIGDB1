﻿using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class RemoverFuncionarioService : IRemoverFuncionarioService
    {
        public INotificationContext notificationContext { get; set; }

        private readonly IFuncionarioRepository _funcionarioRepository;

        public RemoverFuncionarioService(IFuncionarioRepository funcionarioRepository, INotificationContext notification)
        {
            _funcionarioRepository = funcionarioRepository;
            notificationContext = notification;
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
