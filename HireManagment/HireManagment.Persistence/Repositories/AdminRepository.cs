using HireManagment.Application.Contracts.Persistence;
using HireManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Persistence.Repositories
{
    public class AdminRepository : GenericRepository<AdminApi>, IAdminRepository
    {
        private readonly HireManagmentDbContext _dbContext;

        public AdminRepository(HireManagmentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
