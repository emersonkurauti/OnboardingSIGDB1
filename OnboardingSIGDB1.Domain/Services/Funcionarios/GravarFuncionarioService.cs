using AutoMapper;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class GravarFuncionarioService : IGravarFuncionarioService
    {
        public NotificationContext notificationContext { get; set; }
        public int Id { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private Funcionario _funcionario;

        public GravarFuncionarioService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            notificationContext = new NotificationContext();
        }

        public bool Adicionar(FuncionarioDTO dto)
        {
            _funcionario = _mapper.Map<Funcionario>(dto);

            ValidarExisteMesmoCPF(_funcionario.Cpf);
            ValidarCPF(_funcionario.Cpf);
            ValidarEntidade();

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.FuncionarioRepository.Add(_funcionario);
            var inseriu = _unitOfWork.Commit();

            if (!inseriu)
                notificationContext.AddNotification(Constantes.sChaveErroInclusao, Constantes.sMensagemErroInclusao);

            Id = _funcionario.Id;

            return inseriu;
        }

        public bool Alterar(int id, FuncionarioDTO dto)
        {
            throw new NotImplementedException();
        }

        public void ValidarCPF(string cpf)
        {
            if (!ValidadorCPF.ValidaCPF(cpf))
                notificationContext.AddNotification(Constantes.sChaveErroCPFInvalido, Constantes.sMensagemErroCPFInvalido);
        }

        public void ValidarEntidade()
        {
            if (!_funcionario.Validar())
                notificationContext.AddNotifications(_funcionario.ValidationResult);
        }

        public void ValidarExiste(int id)
        {
            throw new NotImplementedException();
        }

        public void ValidarExisteMesmoCPF(string cpf)
        {
            if (_unitOfWork.FuncionarioRepository.Get(e => e.Cpf== cpf) != null)
                notificationContext.AddNotification(Constantes.sChaveErroMesmoCPF, Constantes.sMensagemErroMesmoCPF);
        }
    }
}
