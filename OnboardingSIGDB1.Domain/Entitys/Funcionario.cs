using System;

namespace OnboardingSIGDB1.Domain.Entitys
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataContratacao { get; set; }
        public int CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
