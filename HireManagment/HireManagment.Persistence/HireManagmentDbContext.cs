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

        public DbSet<Candidate>? Student { get; set; }
    }
}
