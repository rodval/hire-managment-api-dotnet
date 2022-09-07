using HireManagment.Domain.Common;
using HireManagment.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Domain
{
    public class OpeningApplication : BaseDomainEntity
    {
        public DateTime DateApplication { get; set; }
        public ApplicationStatusType Status { get; set; }

        public string? CompanyEmployeeId { get; set; }
        public virtual CompanyEmployee? CompanyEmployee { get; set; }

        public string? CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; }
    }
}
