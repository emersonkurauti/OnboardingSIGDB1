using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Notifications;

namespace OnboardingSIGDB1.Domain.Interfaces.Cargos
{
    public interface IGravarCargoService : IGravarService
    {
        bool Adicionar(CargoDTO dto);
        bool Alterar(int id, CargoDTO dto);
    }
}
