using HireManagment.Application.Contracts.Persistence;
using HireManagment.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddDbContext<HireManagmentDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("HireManagementConnectionString")));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IAdminRepository), typeof(AdminRepository));
            services.AddScoped(typeof(ICompanyRepository), typeof(CompanyRepository));
            services.AddScoped(typeof(ICompanyEmployeeRepository), typeof(CompanyEmployeeRepository));
            services.AddScoped(typeof(IOpeningRepository), typeof(OpeningRepository));
            services.AddScoped(typeof(ICandidateRepository), typeof(CandidateRepository));

            return services;
        }
    }
}
