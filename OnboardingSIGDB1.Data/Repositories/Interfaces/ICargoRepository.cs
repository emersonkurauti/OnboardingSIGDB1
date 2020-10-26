using OnboardingSIGDB1.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Data.Repositories.Interfaces
{
    public interface ICargoRepository
    {
        void Adicionar(Cargo cargo);
        IEnumerable<Cargo> ObterTodos();
        Cargo Obter(int cargoId);
        bool Existe(int cargoId);
        void Atualizar(Cargo cargo);
        void Deletar(Cargo cargo);

    }
}
