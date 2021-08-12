using TR.BenFatto.Domain.Entities;
using TR.BenFatto.Infra.Data.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TR.BenFatto.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CategoryMapping());
            builder.ApplyConfiguration(new ProductMapping());
            builder.ApplyConfiguration(new OrderMapping());
            builder.ApplyConfiguration(new UserLogMapping());
        }
    }
}
