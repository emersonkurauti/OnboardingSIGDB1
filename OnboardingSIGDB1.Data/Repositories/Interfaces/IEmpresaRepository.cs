using OnboardingSIGDB1.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Data.Repositories.Interfaces
{
    public interface IEmpresaRepository
    {
        void Adicionar(Empresa empresa);
        IEnumerable<Empresa> ObterTodas();
        Empresa Obter(int empresaId);
        bool Existe(int empresaId);
        void Atualizar(Empresa empresa);
        void Deletar(Empresa empresa);
    }
}
