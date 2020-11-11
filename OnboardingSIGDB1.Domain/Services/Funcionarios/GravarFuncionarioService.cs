using AutoMapper;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Services.Funcionarios.Validadores;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class GravarFuncionarioService : GravarServiceBase, IGravarFuncionarioService
    {
        private Funcionario _funcionario;
        private FuncionarioValidador _validador;

        public GravarFuncionarioService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            notificationContext = new NotificationContext();
            _validador = new FuncionarioValidador(notificationContext, _funcionario, _unitOfWork);
        }

        public bool Adicionar(ref FuncionarioDTO dto)
        {
            _funcionario = new Funcionario(dto.Nome, dto.Cpf);
            _funcionario.AlterarDataContratacao(dto.DataContratacao);

            _validador.entidade = _funcionario;
            _validador.ValidarInclusao();

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.FuncionarioRepository.Add(_funcionario);
            var inseriu = _unitOfWork.Commit();

            if (!inseriu)
                notificationContext.AddNotification(Constantes.sChaveErroInclusao, Constantes.sMensagemErroInclusao);

            dto = _mapper.Map<FuncionarioDTO>(_funcionario);

            return inseriu;
        }

        public bool Alterar(int id, FuncionarioDTO dto)
        {
            _funcionario = _unitOfWork.FuncionarioRepository.Get(f => f.Id == id);
            _funcionario.AlterarNome(dto.Nome);
            _funcionario.AlterarCpf(dto.Cpf);
            _funcionario.AlterarDataContratacao(dto.DataContratacao);

            _validador.entidade = _funcionario;
            _validador.ValidarAlteracao();

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.FuncionarioRepository.Update(_funcionario);
            var alterou = _unitOfWork.Commit();

            if (!alterou)
                notificationContext.AddNotification(Constantes.sChaveErroAlteracao, Constantes.sMensagemErroAlteracao);

            return alterou;
        }

        public bool VincularEmpresa(int id, FuncionarioEmpresaDTO dto)
        {
            _funcionario = _unitOfWork.FuncionarioRepository.Get(f => f.Id == id);
            _funcionario.AlterarEmpresaId(dto.EmpresaId);

            _validador.entidade = _funcionario;
            _validador.ValidarVinculacaoEmpresa();

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.FuncionarioRepository.Update(_funcionario);
            var alterou = _unitOfWork.Commit();

            if (!alterou)
                notificationContext.AddNotification(Constantes.sChaveErroAlteracao, Constantes.sMensagemErroAlteracao);

            return alterou;
        }
    }
}
