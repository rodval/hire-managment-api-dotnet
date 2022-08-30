using HireManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Domain.Utilities
{
    public class OpeningApplication : BaseDomainEntity
    {
        public DateTime DateApplication { get; set; }
        public ApplicationStatusType Status { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

        public int CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; }
    }
}
