using HireManagment.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HireManagmentDbContext _context;
        private IAdminRepository _adminRepository;
        private ICompanyRepository _companyRepository;

        public UnitOfWork(HireManagmentDbContext context)
        {
            _context = context;
        }

        public IAdminRepository AdminRepository =>
            _adminRepository ??= new AdminRepository(_context);

        public ICompanyRepository CompanyRepository =>
            _companyRepository ??= new CompanyRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
