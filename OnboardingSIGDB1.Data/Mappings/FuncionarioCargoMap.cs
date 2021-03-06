﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingSIGDB1.Domain.Entitys;

namespace OnboardingSIGDB1.Data.Mappings
{
    public class FuncionarioCargoMap : IEntityTypeConfiguration<FuncionarioCargo>
    {
        public void Configure(EntityTypeBuilder<FuncionarioCargo> builder)
        {
            builder.HasKey(f => new { f.CargoId, f.FuncionarioId });
            builder.HasOne(f => f.Cargo)
                .WithMany(c => c.FuncionarioCargo)
                .HasForeignKey(f => f.CargoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(f => f.Funcionario)
                .WithMany(f => f.FuncionarioCargo)
                .HasForeignKey(f => f.FuncionarioId);
            builder.Ignore(f => f.ValidationResult);
            builder.Ignore(f => f.CascadeMode);
        }
    }
}
