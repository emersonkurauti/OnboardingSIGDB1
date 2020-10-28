using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Notifications;

namespace OnboardingSIGDB1.Domain.Interfaces.Empresas
{
    public interface IGravarEmpresaService
    {
        NotificationContext notificationContext { get; set; }
        int Id { get; set; }

        void ValidarEntidade();
        void ValidarExisteMesmoCNPJ(string cnpj);
        void ValidarEmpresaExiste(int id);
        void ValidarCNPJ(string cnpj);
        bool Adicionar(EmpresaDTO dto);
        bool Alterar(int id, EmpresaDTO dto);
    }
}
