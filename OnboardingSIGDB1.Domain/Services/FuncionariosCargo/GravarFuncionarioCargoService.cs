using AutoMapper;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Services.FuncionariosCargo
{
    public class GravarFuncionarioCargoService : IGravarFuncionarioCargoService
    {
        public NotificationContext notificationContext { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private FuncionarioCargo _funcionarioCargo;

        public GravarFuncionarioCargoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            notificationContext = new NotificationContext();
        }

        public bool Adicionar(FuncionarioCargoDTO dto)
        {
            _funcionarioCargo = _mapper.Map<FuncionarioCargo>(dto);

            ValidarEmpresaVinculada(_funcionarioCargo.FuncionarioId);
            ValidarExiste(_funcionarioCargo.CargoId, _funcionarioCargo.FuncionarioId);
            ValidarEntidade();

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.FuncionarioCargoRepository.Add(_funcionarioCargo);
            var inseriu = _unitOfWork.Commit();

            if (!inseriu)
                notificationContext.AddNotification(Constantes.sChaveErroInclusao, Constantes.sMensagemErroInclusao);

            return inseriu;
        }

        public void ValidarEmpresaVinculada(int id)
        {
            var funcionario = _unitOfWork.FuncionarioRepository.Get(f => f.Id == id);

            if (funcionario.EmpresaId == null)
                notificationContext.AddNotification(Constantes.sChaveErroFuncionarioSemEmpresa, Constantes.sMensagemErroFuncionarioSemEmpresa);
        }

        public void ValidarEntidade()
        {
            if (!_funcionarioCargo.Validar())
                notificationContext.AddNotifications(_funcionarioCargo.ValidationResult);
        }

        public void ValidarExiste(int cargoId, int funcionarioId)
        {
            if (_unitOfWork.FuncionarioCargoRepository.Exist(fc => fc.CargoId == cargoId && fc.FuncionarioId == funcionarioId))
                notificationContext.AddNotification(Constantes.sChaveErrooFuncionarioCargo, Constantes.sMensagemErrooFuncionarioCargo);
        }

        public void ValidarExiste(int id)
        {
            throw new NotImplementedException();
        }
    }
}
