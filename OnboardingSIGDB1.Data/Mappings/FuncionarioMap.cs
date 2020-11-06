using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingSIGDB1.Domain.Entitys;

namespace OnboardingSIGDB1.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {        
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(f => f.Cpf)
                .IsRequired()
                .HasMaxLength(11);
            builder.HasOne(f => f.Empresa)
                .WithMany(e => e.Funcionarios)
                .HasForeignKey(f => f.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Ignore(f => f.ValidationResult);
            builder.Ignore(f => f.CascadeMode);
        }
    }
}
