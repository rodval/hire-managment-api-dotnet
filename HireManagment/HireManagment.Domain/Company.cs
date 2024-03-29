﻿using HireManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Domain
{
    public class Company : BaseDomainEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }

        public string? AdminId { get; set; }
        public virtual AdminApi? Admin { get; set; }
    }
}
