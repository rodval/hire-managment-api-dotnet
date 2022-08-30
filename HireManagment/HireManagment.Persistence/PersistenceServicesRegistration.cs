using HireManagment.Application.Persistence.Contracts;
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
               options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=hireManagment_db;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
