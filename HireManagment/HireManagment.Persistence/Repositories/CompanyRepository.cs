using HireManagment.Application.Contracts.Persistence;
using HireManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Persistence.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly HireManagmentDbContext _dbContext;

        public CompanyRepository(HireManagmentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
