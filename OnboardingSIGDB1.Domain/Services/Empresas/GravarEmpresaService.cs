﻿using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Empresas;
using OnboardingSIGDB1.Domain.Services.Empresas.Validadores;

namespace OnboardingSIGDB1.Domain.Services.Empresas
{
    public class GravarEmpresaService : GravarServiceBase, IGravarEmpresaService
    {
        private readonly IRepository<Empresa> _empreaRepository;
        private Empresa _empresa;
        private EmpresaValidador _validador;

        public GravarEmpresaService(IRepository<Empresa> empreaRepository, INotificationContext notification)
        {
            _empreaRepository = empreaRepository;
            notificationContext = notification;
            _validador = new EmpresaValidador(notificationContext, _empresa, _empreaRepository);
        }

        public bool Adicionar(EmpresaDTO dto)
        {
            _empresa = new Empresa(dto.Nome, dto.Cnpj);
            _empresa.AlterarDataFundacao(dto.DataFundacao);

            _validador.entidade = _empresa;
            _validador.ValidarInclusao();

            if (notificationContext.HasNotifications)
                return false;

            _empreaRepository.Add(_empresa);
            return true;
        }

        public bool Alterar(int id, EmpresaDTO dto)
        {
            _empresa = _empreaRepository.Get(e => e.Id == id);
            _empresa.AlterarNome(dto.Nome);
            _empresa.AlterarCnpj(dto.Cnpj);
            _empresa.AlterarDataFundacao(dto.DataFundacao);

            _validador.entidade = _empresa;
            _validador.ValidarAlteracao();

            if (notificationContext.HasNotifications)
                return false;

            _empreaRepository.Update(_empresa);
            return true;
        }
    }
}
