using HireManagment.Application.Contracts.Identity;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.Models.Identity;
using HireManagment.Domain;
using HireManagment.Persistence.Repositories;
using HireManagment.Persistence.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<HireManagmentDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("HireManagementConnectionString")));

            services.AddIdentity<AdminApi, IdentityRole>()
                .AddEntityFrameworkStores<HireManagmentDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AdminApiAuthService>();

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IAdminRepository), typeof(AdminRepository));
            services.AddScoped(typeof(ICompanyRepository), typeof(CompanyRepository));
            services.AddScoped(typeof(ICompanyEmployeeRepository), typeof(CompanyEmployeeRepository));
            services.AddScoped(typeof(IOpeningRepository), typeof(OpeningRepository));
            services.AddScoped(typeof(ICandidateRepository), typeof(CandidateRepository));
            services.AddScoped(typeof(IOpeningApplicationRepository), typeof(OpeningApplicationRepository));

            return services;
        }
    }
}
