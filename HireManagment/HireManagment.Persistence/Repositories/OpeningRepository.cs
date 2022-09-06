using HireManagment.Application.Contracts.Persistence;
using HireManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Persistence.Repositories
{
    public class OpeningRepository : GenericRepository<Opening>, IOpeningRepository
    {
        private readonly HireManagmentDbContext _dbContext;

        public OpeningRepository(HireManagmentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
