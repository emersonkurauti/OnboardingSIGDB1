using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Cargos;
using OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Cargos
{
    public class RemoverCargoService : IRemoverCargoService
    {
        public INotificationContext notificationContext { get; set; }
        private readonly IRepository<Cargo> _cargoRepository;
        private readonly IConsultarFuncionarioCargo _consultarFuncionarioCargo;

        public RemoverCargoService(IRepository<Cargo> cargoRepository, IConsultarFuncionarioCargo consultarFuncionarioCargo, INotificationContext notification)
        {
            notificationContext = notification;
            _cargoRepository = cargoRepository;
            _consultarFuncionarioCargo = consultarFuncionarioCargo;
        }

        public bool Remover(int id)
        {
            var cargo = _cargoRepository.Get(c => c.Id == id);

            if (cargo == null)
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);

            if (_consultarFuncionarioCargo.VerificarExisteVinculo(cargo.Id))
                notificationContext.AddNotification(Constantes.sChaveErroCargoFuncionario, Constantes.sMensagemErroCargoFuncionario);

            if (notificationContext.HasNotifications)
                return false;

            _cargoRepository.Delete(cargo);
            return true;
        }
    }
}
