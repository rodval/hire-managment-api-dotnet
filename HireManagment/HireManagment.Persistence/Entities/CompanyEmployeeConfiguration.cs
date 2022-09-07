using HireManagment.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireManagment.Domain.Utilities;
using Microsoft.AspNetCore.Identity;

namespace HireManagment.Persistence.Entities
{
    public class CompanyEmployeeConfiguration : IEntityTypeConfiguration<CompanyEmployee>
    {
        public void Configure(EntityTypeBuilder<CompanyEmployee> builder)
        {
            var hasher = new PasswordHasher<CompanyEmployee>();

            builder.HasData(
                new CompanyEmployee
                {
                    Id = "1",
                    FirstName = "Henry",
                    LastName = "Walas",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmployeeType = EmployeeType.CompanyAdmin,
                    CompanyId = 1
                },
                new CompanyEmployee
                {
                    Id = "2",
                    FirstName = "Brook",
                    LastName = "Bane",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmployeeType = EmployeeType.Employee,
                    CompanyId = 1
                },
                new CompanyEmployee
                {
                    Id = "3",
                    FirstName = "Harry",
                    LastName = "Stevens",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmployeeType = EmployeeType.CompanyAdmin,
                    CompanyId = 2
                },
                new CompanyEmployee
                {
                    Id = "4",
                    FirstName = "Alfonse",
                    LastName = "Elric",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmployeeType = EmployeeType.CompanyAdmin,
                    CompanyId = 3
                }
            );
        }
    }
}
