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
        /*ICandidateRepository CandidateRepository { get; }
        ICompanyEmployeeRepository CompanyEmployee { get; }
        ICompanyRepository CompanyRepository { get; }
        IOpeningApplicationRepository OpeningApplicationRepository { get; }
        IOpeningRepository OpeningRepository { get; }*/
        Task Save();
    }
}
