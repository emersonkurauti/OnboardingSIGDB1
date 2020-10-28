using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class GravarFuncionarioService : IGravarFuncionarioService
    {
        public NotificationContext notificationContext { get; set; }
        public int Id { get; set; }

        public bool Adicionar(FuncionarioDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Alterar(int id, FuncionarioDTO dto)
        {
            throw new NotImplementedException();
        }

        public void ValidarCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        public void ValidarEntidade()
        {
            throw new NotImplementedException();
        }

        public void ValidarExiste(int id)
        {
            throw new NotImplementedException();
        }

        public void ValidarExisteMesmoCPF(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
