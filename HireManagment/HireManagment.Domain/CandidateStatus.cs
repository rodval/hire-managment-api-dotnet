using HireManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Domain
{
    public class CandidateStatus : BaseDomainEntity
    {
        public string? Status { get; set; }
    }
}
