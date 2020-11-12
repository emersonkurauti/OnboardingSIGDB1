﻿using AutoMapper;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Services.Funcionarios.Validadores;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class GravarFuncionarioService : GravarServiceBase, IGravarFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private Funcionario _funcionario;
        private FuncionarioValidador _validador;

        public GravarFuncionarioService(IMapper mapper, IFuncionarioRepository funcionarioRepository, IRepository<Empresa> empresaRepository)
        {
            _mapper = mapper;
            _funcionarioRepository = funcionarioRepository;
            notificationContext = new NotificationContext();
            _validador = new FuncionarioValidador(notificationContext, _funcionario, _funcionarioRepository, empresaRepository);
        }

        public bool Adicionar(ref FuncionarioDTO dto)
        {
            _funcionario = new Funcionario(dto.Nome, dto.Cpf);
            _funcionario.AlterarDataContratacao(dto.DataContratacao);

            _validador.entidade = _funcionario;
            _validador.ValidarInclusao();

            if (notificationContext.HasNotifications)
                return false;

            _funcionarioRepository.Add(_funcionario);
            return true;
        }

        public bool Alterar(int id, FuncionarioDTO dto)
        {
            _funcionario = _funcionarioRepository.Get(f => f.Id == id);
            _funcionario.AlterarNome(dto.Nome);
            _funcionario.AlterarCpf(dto.Cpf);
            _funcionario.AlterarDataContratacao(dto.DataContratacao);

            _validador.entidade = _funcionario;
            _validador.ValidarAlteracao();

            if (notificationContext.HasNotifications)
                return false;

            _funcionarioRepository.Update(_funcionario);
            return true;
        }

        public bool VincularEmpresa(int id, FuncionarioEmpresaDTO dto)
        {
            _funcionario = _funcionarioRepository.Get(f => f.Id == id);
            _funcionario.AlterarEmpresaId(dto.EmpresaId);

            _validador.entidade = _funcionario;
            _validador.ValidarVinculacaoEmpresa();

            if (notificationContext.HasNotifications)
                return false;

            _funcionarioRepository.Update(_funcionario);
            return true;
        }
    }
}
