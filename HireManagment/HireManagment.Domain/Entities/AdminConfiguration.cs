using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Domain.Entities
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasData(
                new Admin
                {
                    Id = 1,
                    FirstName = "Robert",
                    LastName = "Wade",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com"
                },
                new Admin
                {
                    Id = 2,
                    FirstName = "Felix",
                    LastName = "Feliz",
                    Age= 32,
                    Email = "rodrigovalladares1@gmail.com"
                }
            );
        }
    }
}
