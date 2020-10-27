using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingSIGDB1.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Data.Mappings
{
    public class CargoMap : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(250);
            builder.Ignore(c => c.ValidationResult);
            builder.Ignore(f => f.CascadeMode);
        }
    }
}
