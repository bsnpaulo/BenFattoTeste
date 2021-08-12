using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.BenFatto.Domain.Entities;

namespace TR.BenFatto.Infra.Data.Mapping
{
    public class UserLogMapping : IEntityTypeConfiguration<UserLog>
    {
        public void Configure(EntityTypeBuilder<UserLog> builder)
        {
            builder.ToTable("UserLogs");
            
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IpAdress)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(p => p.UserAgent)
                .HasMaxLength(500)
                .IsRequired();

            builder.HasIndex(p => p.IpAdress);
            builder.HasIndex(p => p.LogHour);
            builder.HasIndex(p => p.UserAgent);
        }
    }
}
