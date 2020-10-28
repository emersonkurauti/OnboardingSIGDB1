using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Domain.Services
{
    public class RemoverEmpresaService : IRemoverEmpresaService
    {
        public NotificationContext notificationContext { get; set; }
        public int Id { get; set; }

        private readonly IUnitOfWork _unitOfWork;

        public RemoverEmpresaService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            notificationContext = new NotificationContext();
        }

        public bool Remover(int id)
        {
            var empresa = _unitOfWork.EmpresaRepository.Get(e => e.Id == id);

            if (empresa == null)
                notificationContext.AddNotification("EmpresaNaoLocalizada", "Empresa não localizada para exclusão.");

            if (notificationContext.HasNotifications)
                return false;

            _unitOfWork.EmpresaRepository.Delete(empresa);
            var deletou = _unitOfWork.Commit();

            if (!deletou)
                notificationContext.AddNotification("FalhaRemocaoEmpresa", "Falha ao remover a empresa.");

            return deletou;
        }
    }
}
