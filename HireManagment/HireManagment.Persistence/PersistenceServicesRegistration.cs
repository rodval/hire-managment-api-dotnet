using HireManagment.Application.Contracts.Identity;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.Models.Identity;
using HireManagment.Domain;
using HireManagment.Domain.Common;
using HireManagment.Persistence.Repositories;
using HireManagment.Persistence.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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

            services.AddIdentity<Person, IdentityRole>()
                .AddEntityFrameworkStores<HireManagmentDbContext>().AddDefaultTokenProviders();

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IAdminRepository), typeof(AdminRepository));
            services.AddScoped(typeof(ICompanyRepository), typeof(CompanyRepository));
            services.AddScoped(typeof(ICompanyEmployeeRepository), typeof(CompanyEmployeeRepository));
            services.AddScoped(typeof(IOpeningRepository), typeof(OpeningRepository));
            services.AddScoped(typeof(ICandidateRepository), typeof(CandidateRepository));
            services.AddScoped(typeof(IOpeningApplicationRepository), typeof(OpeningApplicationRepository));

            services.AddTransient(typeof(ICandidateAuthService), typeof(CandidateAuthService));
            services.AddTransient(typeof(ICompanyEmployeeAuthService), typeof(CompanyEmployeeAuthService));
            
            services.AddTransient(typeof(IAdminApiAuthService), typeof(AdminApiAuthService));
            
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(configuration.GetSection("JwtSettings:Key").Value))
                };
            });

            return services;
        }
    }
}
