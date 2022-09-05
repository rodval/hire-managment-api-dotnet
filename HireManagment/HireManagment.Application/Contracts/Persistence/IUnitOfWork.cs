using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepository AdminRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        ICompanyEmployeeRepository CompanyEmployeeRepository { get; }
        IOpeningRepository OpeningRepository { get; }
        ICandidateRepository CandidateRepository { get; }
        IOpeningApplicationRepository OpeningApplicationRepository { get; }
        Task Save();
    }
}
