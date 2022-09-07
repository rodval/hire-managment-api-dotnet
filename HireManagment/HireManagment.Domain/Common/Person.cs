using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Domain.Common
{
    public class Person : IdentityUser
    {
        public string? FirstName { get; set; }   
        public string? LastName { get; set; }
        public int? Age { get; set; }
    }
}
