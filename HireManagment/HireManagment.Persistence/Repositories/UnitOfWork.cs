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
        private ICompanyEmployeeRepository _companyEmployeeRepository;
        private IOpeningRepository _openingRepository;
        private ICandidateRepository _candidateRepository;
        private IOpeningApplicationRepository _openingApplicationRepository;

        public UnitOfWork(HireManagmentDbContext context)
        {
            _context = context;
        }

        public IAdminRepository AdminRepository =>
            _adminRepository ??= new AdminRepository(_context);

        public ICompanyRepository CompanyRepository =>
            _companyRepository ??= new CompanyRepository(_context);

        public ICompanyEmployeeRepository CompanyEmployeeRepository =>
            _companyEmployeeRepository ??= new CompanyEmployeeRepository(_context);

        public IOpeningRepository OpeningRepository =>
            _openingRepository ??= new OpeningRepository(_context);

        public ICandidateRepository CandidateRepository =>
            _candidateRepository ??= new CandidateRepository(_context);

        public IOpeningApplicationRepository OpeningApplicationRepository =>
            _openingApplicationRepository ??= new OpeningApplicationRepository(_context);

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
