using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Models.Identity
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public double DurationInMinutes { get; set; }
    }
}
