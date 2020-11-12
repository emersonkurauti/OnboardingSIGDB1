﻿using AutoMapper;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Cargos;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Services.Cargos.Validadores;

namespace OnboardingSIGDB1.Domain.Services.Cargos
{
    public class GravarCargoService : GravarServiceBase, IGravarCargoService
    {
        private readonly IRepository<Cargo> _cargoRepository;
        private Cargo _cargo;
        private CargoValidador _validador;

        public GravarCargoService(IRepository<Cargo> cargoRepository, IMapper mapper)
        {
            notificationContext = new NotificationContext();
            _cargoRepository = cargoRepository;
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

            _cargoRepository.Add(_cargo);
            dto = _mapper.Map<CargoDTO>(_cargo);
            return true;
        }

        public bool Alterar(int id, CargoDTO dto)
        {
            _cargo = _cargoRepository.Get(c => c.Id == id);
            _cargo.AlterarDescricao(dto.Descricao);

            _validador.entidade = _cargo;
            _validador.ValidarAlteracao();

            if (notificationContext.HasNotifications)
                return false;

            _cargoRepository.Update(_cargo);
            return true;
        }

    }
}
