using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Cargos.Validadores
{
    public class CargoValidador : ValidadorBase<Cargo>
    {
        private readonly IRepository<Cargo> _cargoRepository;

        public CargoValidador(INotificationContext notification, Cargo cargo, IRepository<Cargo> cargoRepository) 
        {
            _cargoRepository = cargoRepository;
            notificationContext = notification;
            entidade = cargo;
        }

        public void ValidarInclusao()
        {
            ValidarEntidade();
            ValidarExisteMesmaDescricao();
        }

        public void ValidarAlteracao()
        {
            ValidarExiste();
            ValidarEntidade();
            ValidarExisteMesmaDescricao();
        }

        private void ValidarEntidade()
        {
            if (entidade != null && !entidade.Validar())
                notificationContext.AddNotifications(entidade.ValidationResult);
        }

        private void ValidarExiste()
        {
            if (entidade == null)
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);
        }

        private void ValidarExisteMesmaDescricao()
        {
            if (entidade != null && _cargoRepository.Exist(c => c.Descricao == entidade.Descricao))
                notificationContext.AddNotification(Constantes.sChaveErroCargoMesmaDescricao, Constantes.sMensagemErroCargoMesmaDescricao);
        }
    }
}
