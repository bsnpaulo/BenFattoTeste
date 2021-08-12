using TR.BenFatto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace TR.BenFatto.Infra.Data.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasData(

                    new Category { Id = 1, Name = "Recicláveis" },
                    new Category { Id = 2, Name = "Eletrônicos" }

                );
        }

    }
}
