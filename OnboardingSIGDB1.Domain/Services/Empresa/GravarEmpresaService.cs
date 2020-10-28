using AutoMapper;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services
{
    public class GravarEmpresaService : IGravarService
    {
        public NotificationContext notificationContext { get; set; }
        public int Id { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private Empresa _empresa;

        public GravarEmpresaService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            notificationContext = new NotificationContext();
        }

        public bool Adicionar(EmpresaDTO dto)
        {
            _empresa = _mapper.Map<Empresa>(dto);

            ValidarExisteMesmoCNPJ(_empresa.Cnpj);
            ValidarCNPJ(_empresa.Cnpj);
            ValidarEntidade();

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.EmpresaRepository.Add(_empresa);
            var inseriu = _unitOfWork.Commit();

            if (!inseriu)
                notificationContext.AddNotification(Constantes.sChaveErroInclusao, Constantes.sMensagemErroInclusao);

            Id = _empresa.Id;

            return inseriu;
        }

        public bool Alterar(int id, EmpresaDTO dto)
        {
            _empresa = _mapper.Map<Empresa>(dto);

            ValidarEmpresaExiste(id);
            ValidarCNPJ(_empresa.Cnpj);
            ValidarEntidade();

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.EmpresaRepository.Update(_empresa);
            var alterou = _unitOfWork.Commit();

            if (!alterou)
                notificationContext.AddNotification("AlterarEmpresa", "Não possível realizar a alteração.");

            return alterou;
        }

        public void ValidarEntidade()
        {
            if (!_empresa.Validar())
                notificationContext.AddNotifications(_empresa.ValidationResult);
        }

        public void ValidarExisteMesmoCNPJ(string cnpj)
        {
            if (_unitOfWork.EmpresaRepository.Get(e => e.Cnpj == cnpj) != null)
                notificationContext.AddNotification("EmpresaComMesmoCNPJ", "CNPJ já incluído na base.");
        }

        public void ValidarCNPJ(string cnpj)
        {
            if (!ValidadorCPNJ.ValidaCNPJ(cnpj))
                notificationContext.AddNotification("ValidadorCNPJ", "CNPJ inválido");
        }

        public void ValidarEmpresaExiste(int id)
        {
            if (!_unitOfWork.EmpresaRepository.Exist(e => e.Id == id))
                notificationContext.AddNotification("EmpresaNaoLocalizada", "Empresa não localizada para alteração.");
        }
    }
}
