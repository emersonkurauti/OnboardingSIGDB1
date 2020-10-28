using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Notifications;

namespace OnboardingSIGDB1.Domain.Interfaces.Cargos
{
    public interface IGravarCargoService
    {
        NotificationContext notificationContext { get; set; }
        int Id { get; set; }

        void ValidarEntidade();
        void ValidarCargoExiste(int id);
        bool Adicionar(CargoDTO dto);
        bool Alterar(int id, CargoDTO dto);
    }
}
