using HireManagment.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Persistence
{
    public class HireManagmentDbContext : DbContext
    {
        public HireManagmentDbContext(DbContextOptions<HireManagmentDbContext> options)
            : base(options) 
        { 
        }

        public DbSet<CompanyAdmin>? CompanyAdmins { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<CompanyEmployee>? CompanyEmployees { get; set; }
        public DbSet<Opening>? Openings { get; set; }
        public DbSet<Candidate>? Candidates { get; set; }
        public DbSet<OpeningApplication>? OpeningApplications { get; set; }
    }
}
