using AutoMapper;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Domain.Services
{
    public class GravarEmpresaService : IGravarEmpresaService
    {
        public NotificationContext notificationContext { get; set; }
        public int Id { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GravarEmpresaService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            notificationContext = new NotificationContext();
        }

        public async Task<bool> Adicionar(EmpresaDTO dto)
        {
            var empresa = _mapper.Map<Empresa>(dto);

            if (!empresa.Validar())
                notificationContext.AddNotifications(empresa.ValidationResult);

            if (!ValidadorCPNJ.ValidaCNPJ(empresa.Cnpj))
                notificationContext.AddNotification("ValidadorCNPJ", "CNPJ inválido");

            if (_unitOfWork.EmpresaRepository.Get(e => e.Cnpj == empresa.Cnpj) != null)
                notificationContext.AddNotification("EmpresaComMesmoCNPJ", "CNPJ já incluído na base.");

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.EmpresaRepository.Add(empresa);
            _unitOfWork.Commit();

            Id = empresa.Id;

            return true;
        }
    }
}
