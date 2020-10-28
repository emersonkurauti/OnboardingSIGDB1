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
    public interface IGravarService
    {
        NotificationContext notificationContext { get; set; }
        int Id { get; set; }

        void ValidarEntidade();
        void ValidarExisteMesmoCNPJ(string cnpj);
        void ValidarEmpresaExiste(int id);
        void ValidarCNPJ(string cnpj);
        bool Adicionar(EmpresaDTO dto);
        bool Alterar(int id, EmpresaDTO dto);
    }
}
