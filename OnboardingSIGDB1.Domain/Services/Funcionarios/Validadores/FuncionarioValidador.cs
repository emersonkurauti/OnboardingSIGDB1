using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios.Validadores
{
    public class FuncionarioValidador: ValidadorBase<Funcionario>
    {
        private IFuncionarioRepository _funcionarioRepository;
        private IRepository<Empresa> _empresaRepository;

        public FuncionarioValidador(NotificationContext notification, Funcionario funcionario, IFuncionarioRepository funcionarioRepository,
            IRepository<Empresa> empresaRepository)
        {
            notificationContext = notification;
            entidade = funcionario;
            _funcionarioRepository = funcionarioRepository;
            _empresaRepository = empresaRepository;
        }

        public void ValidarInclusao()
        {
            ValidarExisteMesmoCPF(entidade.Cpf);
            ValidarCPF(entidade.Cpf);
            ValidarEntidade();
        }

        public void ValidarAlteracao()
        {
            ValidarExiste();
            ValidarCPF(entidade.Cpf);
            ValidarEntidade();
        }

        public void ValidarVinculacaoEmpresa()
        {
            ValidarExiste();
            ValidarEmpresaVinculada();
            ValidarEmpresaExiste();
        }

        private void ValidarCPF(string cpf)
        {
            if (!ValidadorCPF.ValidaCPF(cpf))
                notificationContext.AddNotification(Constantes.sChaveErroCPFInvalido, Constantes.sMensagemErroCPFInvalido);
        }

        private void ValidarEntidade()
        {
            if (!entidade.Validar())
                notificationContext.AddNotifications(entidade.ValidationResult);
        }

        private void ValidarExiste()
        {
            if (entidade == null)
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);
        }

        private void ValidarExisteMesmoCPF(string cpf)
        {
            if (_funcionarioRepository.Exist(f => f.Cpf == cpf))
                notificationContext.AddNotification(Constantes.sChaveErroMesmoCPF, Constantes.sMensagemErroMesmoCPF);
        }

        private void ValidarEmpresaVinculada()
        {
            if (entidade != null && entidade.EmpresaId.HasValue)
                notificationContext.AddNotification(Constantes.sChaveErroEmpresaVinculada, Constantes.sMensagemErroEmpresaVinculada);
        }

        private void ValidarEmpresaExiste()
        {
            if (!_empresaRepository.Exist(e => e.Id == entidade.EmpresaId))
                notificationContext.AddNotification(Constantes.sChaveErroEmpresaNaoLocalizadaParaVincular, Constantes.sMensagemErroEmpresaNaoLocalizadaParaVincular);
        }
    }
}
