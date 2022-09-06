using HireManagment.Domain.Common;
using HireManagment.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Domain
{
    public class CompanyEmployee : Person
    {
        public EmployeeType EmployeeType { get; set; }

        public int CompanyId { get; set; }
        public virtual Company? Company { get; set; }
    }
}
