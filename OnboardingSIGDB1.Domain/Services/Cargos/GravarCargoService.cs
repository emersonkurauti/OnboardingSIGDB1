using AutoMapper;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Cargos;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Services.Cargos.Validadores;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Cargos
{
    public class GravarCargoService : GravarServiceBase, IGravarCargoService
    {
        private Cargo _cargo;
        private CargoValidador _validador;

        public GravarCargoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            notificationContext = new NotificationContext();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validador = new CargoValidador(notificationContext, _cargo);
        }

        public bool Adicionar(ref CargoDTO dto)
        {
            _cargo = new Cargo(dto.Descricao);

            _validador.entidade = _cargo;
            _validador.ValidarInclusao();

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
            _cargo.AlterarDescricao(dto.Descricao);

            _validador.entidade = _cargo;
            _validador.ValidarAlteracao();

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.CargoRepository.Update(_cargo);
            var alterou = _unitOfWork.Commit();

            if (!alterou)
                notificationContext.AddNotification(Constantes.sChaveErroAlteracao, Constantes.sMensagemErroAlteracao);

            return alterou;
        }

    }
}
