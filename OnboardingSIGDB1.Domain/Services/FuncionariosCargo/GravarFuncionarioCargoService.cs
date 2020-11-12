using AutoMapper;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo;
using OnboardingSIGDB1.Domain.Services.FuncionariosCargo.Validadores;

namespace OnboardingSIGDB1.Domain.Services.FuncionariosCargo
{
    public class GravarFuncionarioCargoService : GravarServiceBase, IGravarFuncionarioCargoService
    {
        private readonly IRepository<FuncionarioCargo> _funcionarioCargoRepository;
        private FuncionarioCargo _funcionarioCargo;
        private FuncionarioCargoValidador _validador;

        public GravarFuncionarioCargoService(IRepository<FuncionarioCargo> funcionarioCargoRepository, IMapper mapper, INotificationContext notification,
            IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioCargoRepository = funcionarioCargoRepository;
            _mapper = mapper;
            notificationContext = notification;
            _validador = new FuncionarioCargoValidador(notificationContext, _funcionarioCargo, funcionarioCargoRepository, funcionarioRepository);
        }

        public bool Adicionar(FuncionarioCargoDTO dto)
        {
            _funcionarioCargo = new FuncionarioCargo(dto.CargoId, dto.FuncionarioId, dto.DataVinculo);

            _validador.entidade = _funcionarioCargo;
            _validador.ValidarVinculoFuncionarioCargo();

            if (notificationContext.HasNotifications)
                return false;

            _funcionarioCargoRepository.Add(_funcionarioCargo);
            return true;
        }
    }
}
