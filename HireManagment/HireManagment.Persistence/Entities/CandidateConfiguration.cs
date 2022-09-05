using HireManagment.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Persistence.Entities
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasData(
                new Candidate
                {
                    Id = 1,
                    FirstName = "Omar",
                    LastName = "Strange",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com"
                },
                new Candidate
                {
                    Id = 2,
                    FirstName = "Ruben",
                    LastName = "Dario",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com"
                }
            );
        }
    }
}
