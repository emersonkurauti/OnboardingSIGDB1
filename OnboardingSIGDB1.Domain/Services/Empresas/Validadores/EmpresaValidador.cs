using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Empresas.Validadores
{
    public class EmpresaValidador : ValidadorBase<Empresa>
    {
        private readonly IRepository<Empresa> _empresaRepository;

        public EmpresaValidador(INotificationContext notification, Empresa empresa, IRepository<Empresa> empresaRepository)
        {
            notificationContext = notification;
            entidade = empresa;
            _empresaRepository = empresaRepository;
        }

        public void ValidarInclusao()
        {
            ValidarExisteMesmoCNPJ(entidade.Cnpj);
            ValidarCNPJ(entidade.Cnpj);
            ValidarEntidade();
        }

        public void ValidarAlteracao()
        {
            ValidarExiste();
            ValidarCNPJ(entidade.Cnpj);
            ValidarEntidade();
        }

        private void ValidarEntidade()
        {
            if (!entidade.Validar())
                notificationContext.AddNotifications(entidade.ValidationResult);
        }

        private void ValidarExisteMesmoCNPJ(string cnpj)
        {
            if (_empresaRepository.Exist(e => e.Cnpj == cnpj))
                notificationContext.AddNotification(Constantes.sChaveErroMesmoCNPJ, Constantes.sMensagemErroMesmoCNPJ);
        }

        private void ValidarCNPJ(string cnpj)
        {
            if (entidade != null && !ValidadorCPNJ.ValidaCNPJ(cnpj))
                notificationContext.AddNotification(Constantes.sChaveErroCNPJInvalido, Constantes.sMensagemErroCNPJInvalido);
        }

        private void ValidarExiste()
        {
            if (entidade == null)
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);
        }
    }
}
