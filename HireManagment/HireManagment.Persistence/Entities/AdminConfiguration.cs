using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Domain.Entities
{
    public class AdminConfiguration : IEntityTypeConfiguration<AdminApi>
    {
        public void Configure(EntityTypeBuilder<AdminApi> builder)
        {
            var hasher = new PasswordHasher<AdminApi>();

            builder.HasData(
                new AdminApi
                {
                    Id = 1,
                    FirstName = "Robert",
                    LastName = "Wade",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com",
                    Password = hasher.HashPassword(null, "P@ssword1")
                },
                new AdminApi
                {
                    Id = 2,
                    FirstName = "Felix",
                    LastName = "Feliz",
                    Age= 32,
                    Email = "rodrigovalladares1@gmail.com",
                    Password = hasher.HashPassword(null, "P@ssword1")
                }
            );
        }
    }
}
