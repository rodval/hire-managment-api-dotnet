using HireManagment.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using Microsoft.AspNetCore.Identity;

namespace HireManagment.Persistence.Entities
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            var hasher = new PasswordHasher<Candidate>();

            builder.HasData(
                new Candidate
                {
                    Id = "1",
                    FirstName = "Omar",
                    LastName = "Strange",
                    Age = 32,
                    Email = "rodrigovalladare1@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                },
                new Candidate
                {
                    Id = "2",
                    FirstName = "Ruben",
                    LastName = "Dario",
                    Age = 32,
                    Email = "candidate2@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword2")
                }
            );
        }
    }
}
