using AutoMapper;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Empresas;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Services.Empresas.Validadores;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Empresas
{
    public class GravarEmpresaService : GravarServiceBase, IGravarEmpresaService
    {
        private Empresa _empresa;
        private EmpresaValidador _validador;

        public GravarEmpresaService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            notificationContext = new NotificationContext();
            _validador = new EmpresaValidador(notificationContext, _empresa, _unitOfWork);
        }

        public bool Adicionar(ref EmpresaDTO dto)
        {
            _empresa = new Empresa(dto.Nome, dto.Cnpj);
            _empresa.AlterarDataFundacao(dto.DataFundacao);

            _validador.entidade = _empresa;
            _validador.ValidarInclusao();

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.EmpresaRepository.Add(_empresa);
            var inseriu = _unitOfWork.Commit();

            if (!inseriu)
                notificationContext.AddNotification(Constantes.sChaveErroInclusao, Constantes.sMensagemErroInclusao);

            dto = _mapper.Map<EmpresaDTO>(_empresa);

            return inseriu;
        }

        public bool Alterar(int id, EmpresaDTO dto)
        {
            _empresa = _unitOfWork.EmpresaRepository.Get(e => e.Id == id);
            _empresa.AlterarNome(dto.Nome);
            _empresa.AlterarCnpj(dto.Cnpj);
            _empresa.AlterarDataFundacao(dto.DataFundacao);

            _validador.entidade = _empresa;
            _validador.ValidarAlteracao();

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.EmpresaRepository.Update(_empresa);
            var alterou = _unitOfWork.Commit();

            if (!alterou)
                notificationContext.AddNotification(Constantes.sChaveErroAlteracao, Constantes.sMensagemErroAlteracao);

            return alterou;
        }
    }
}
