using HireManagment.Application.Contracts.Persistence;
using HireManagment.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Persistence.Repositories
{
    public class OpeningApplicationRepository : GenericRepository<OpeningApplication>, IOpeningApplicationRepository
    {
        private readonly HireManagmentDbContext _dbContext;

        public OpeningApplicationRepository(HireManagmentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<OpeningApplication>> GetCandidatesApplication(string id)
        {
            return await _dbContext.Set<OpeningApplication>().Where(o => o.CandidateId == id).ToListAsync();
        }
    }
}
