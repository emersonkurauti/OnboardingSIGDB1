using AutoMapper;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Domain.Interfaces
{
    public interface IGravarEmpresaService
    {
        NotificationContext notificationContext { get; set; }
        int Id { get; set; }
        Task<bool> Adicionar(EmpresaDTO dto);
    }
}
