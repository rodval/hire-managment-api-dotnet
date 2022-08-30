using HireManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Persistence.Contracts
{
    internal interface ICompanyEmployee : IGenericRepository<CompanyEmployee>
    {
    }
}
