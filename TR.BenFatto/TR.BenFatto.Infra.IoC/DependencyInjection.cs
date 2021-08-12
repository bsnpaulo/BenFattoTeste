using TR.BenFatto.Application.Interfaces;
using TR.BenFatto.Application.Services;
using TR.BenFatto.Domain.Interfaces;
using TR.BenFatto.Infra.Data.Context;
using TR.BenFatto.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TR.BenFatto.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region SQL Server
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region MySQL
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseMySql(configuration.GetConnectionString("MySQLConnection"), new MySqlServerVersion(new Version(8, 0, 11))));
            #endregion

            #region Postgres
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("PostegresConnection")));
            #endregion

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IUserLogRepository, UserLogRepository>();
            services.AddScoped<IUserLogService, UserLogService>();

            services.AddScoped<ICreatePostRepository, CreatePostRepository>();
            services.AddScoped<ICreatePostService, CreatePostService>();

            return services;
        }
    }
}
