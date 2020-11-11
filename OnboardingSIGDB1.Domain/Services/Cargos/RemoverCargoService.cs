﻿using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Interfaces.Cargos;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Utils;
using System.Linq;

namespace OnboardingSIGDB1.Domain.Services.Cargos
{
    public class RemoverCargoService : IRemoverCargoService
    {
        public NotificationContext notificationContext { get; set; }

        private readonly IUnitOfWork _unitOfWork;

        public RemoverCargoService(IUnitOfWork unitOfWork)
        {
            notificationContext = new NotificationContext();
            _unitOfWork = unitOfWork;
        }

        public bool Remover(int id)
        {
            var cargo = _unitOfWork.CargoRepository.Get(c => c.Id == id);

            if (cargo == null)
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);

            if (_unitOfWork.FuncionarioCargoRepository.GetAll(fc => fc.CargoId == id).Any())
                notificationContext.AddNotification(Constantes.sChaveErroCargoFuncionario, Constantes.sMensagemErroCargoFuncionario);

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.CargoRepository.Delete(cargo);
            var deletou = _unitOfWork.Commit();

            if (!deletou)
                notificationContext.AddNotification(Constantes.sChaveErroRemover, Constantes.sMensagemErroRemover);

            return deletou;
        }
    }
}
