using OnboardingSIGDB1.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Data.Repositories.Interfaces
{
    public interface IFuncionarioRepository
    {
        void Adicionar(Funcionario funcionario);
        IEnumerable<Funcionario> ObterTodos();
        Funcionario Obter(int funcionarioId);
        bool Existe(int funcionarioId);
        void Atualizar(Funcionario funcionario);
        void Deletar(Funcionario funcionario);

    }
}
