using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Notifications;

namespace OnboardingSIGDB1.Domain.Interfaces.Empresas
{
    public interface IGravarEmpresaService : IGravarService
    {
        void ValidarExisteMesmoCNPJ(string cnpj);
        void ValidarCNPJ(string cnpj);
        bool Adicionar(ref EmpresaDTO dto);
        bool Alterar(int id, EmpresaDTO dto);
    }
}
