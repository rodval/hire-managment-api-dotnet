using HireManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Contracts.Persistence
{
    public interface ICandidateRepository : IGenericRepository<Candidate>
    {
    }
}
