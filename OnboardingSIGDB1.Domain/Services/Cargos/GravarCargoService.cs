using AutoMapper;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Cargos;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Cargos
{
    public class GravarCargoService : IGravarCargoService
    {
        public NotificationContext notificationContext { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private Cargo _cargo;

        public GravarCargoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            notificationContext = new NotificationContext();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool Adicionar(ref CargoDTO dto)
        {
            _cargo = new Cargo(dto.Descricao);

            ValidarEntidade();

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.CargoRepository.Add(_cargo);
            var inseriu = _unitOfWork.Commit();

            if (!inseriu)
                notificationContext.AddNotification(Constantes.sChaveErroInclusao, Constantes.sMensagemErroInclusao);

            dto = _mapper.Map<CargoDTO>(_cargo);

            return inseriu;
        }

        public bool Alterar(int id, CargoDTO dto)
        {
            _cargo = _unitOfWork.CargoRepository.Get(c => c.Id == id);

            ValidarExiste();
            ValidarEntidade();

            if (notificationContext.HasNotifications)
                return false;

            _cargo.AlterarDescricao(dto.Descricao);

            _unitOfWork.CargoRepository.Update(_cargo);
            var alterou = _unitOfWork.Commit();

            if (!alterou)
                notificationContext.AddNotification(Constantes.sChaveErroAlteracao, Constantes.sMensagemErroAlteracao);

            return alterou;
        }

        //Mudar as validações para classes separadas
        public void ValidarEntidade()
        {
            if (_cargo != null && !_cargo.Validar())
                notificationContext.AddNotifications(_cargo.ValidationResult);
        }

        public void ValidarExiste()
        {
            if (_cargo == null)
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);
        }
    }
}
