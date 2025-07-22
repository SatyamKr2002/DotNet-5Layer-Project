using EMS.Repository.Context;
using EMS.Repository.IRepositories;
using EMS.Repository.Repositories;
using EMS.Service.IServices;
using EMS.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEmployeeDependencies(this IServiceCollection services,
            IConfiguration configuration)
        {
            //services.AddDbContext<EMSDbContext>(options =>
            //    options.UseSqlServer("dbcs")); 

            services.AddDbContext<EMSDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("dbcs"),
                        x => x.MigrationsAssembly("EMS.Repository")
                )
            );

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            return services;
        }
    }
}
