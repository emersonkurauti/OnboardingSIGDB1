﻿using AutoMapper;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo;
using OnboardingSIGDB1.Domain.Notifications;

namespace OnboardingSIGDB1.Domain.Services.FuncionariosCargo
{
    public class GravarFuncionarioCargoService : GravarServiceBase, IGravarFuncionarioCargoService
    {
        private readonly IRepository<FuncionarioCargo> _funcionarioCargoRepository;
        private FuncionarioCargo _funcionarioCargo;

        public GravarFuncionarioCargoService(IRepository<FuncionarioCargo> funcionarioCargoRepository, IMapper mapper)
        {
            _funcionarioCargoRepository = funcionarioCargoRepository;
            _mapper = mapper;
            notificationContext = new NotificationContext();
        }

        public bool Adicionar(FuncionarioCargoDTO dto)
        {
            _funcionarioCargo = new FuncionarioCargo(dto.CargoId, dto.FuncionarioId, dto.DataVinculo);            

            if (notificationContext.HasNotifications)
                return false;

            _funcionarioCargoRepository.Add(_funcionarioCargo);
            return true;
        }
    }
}
