using HireManagment.Application.Contracts.Persistence;
using HireManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Persistence.Repositories
{
    public class CompanyEmployeeRepository : GenericRepository<CompanyEmployee>, ICompanyEmployeeRepository
    {
        private readonly HireManagmentDbContext _dbContext;

        public CompanyEmployeeRepository(HireManagmentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<CompanyEmployee> Get(int id)
        {
            return await _dbContext.Set<CompanyEmployee>().FindAsync(id);
        }
    }
}
