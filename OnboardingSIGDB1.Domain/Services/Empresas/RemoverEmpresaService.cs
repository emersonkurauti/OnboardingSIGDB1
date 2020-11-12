using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Empresas;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Empresas
{
    public class RemoverEmpresaService : IRemoverEmpresaService
    {
        public INotificationContext notificationContext { get; set; }

        private readonly IRepository<Empresa> _empreaRepository;
        private readonly IConsultaFuncionario _consultaFuncionario;

        public RemoverEmpresaService(IRepository<Empresa> empreaRepository, IConsultaFuncionario consultaFuncionario, INotificationContext notification)
        {
            _empreaRepository = empreaRepository;
            _consultaFuncionario = consultaFuncionario;
            notificationContext = notification;
        }

        public bool Remover(int id)
        {
            var empresa = _empreaRepository.Get(e => e.Id == id);

            if (empresa == null)
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);

            if (_consultaFuncionario.VerificarEmrpesaVinculada(empresa.Id))
                notificationContext.AddNotification(Constantes.sChaveErroFuncionarioEmpresa, Constantes.sMensagemErroFuncionarioEmpresa);

            if (notificationContext.HasNotifications)
                return false;

            _empreaRepository.Delete(empresa);
            return true;
        }
    }
}
