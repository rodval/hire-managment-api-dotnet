using HireManagment.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireManagment.Domain.Utilities;

namespace HireManagment.Persistence.Entities
{
    public class OpeningConfiguration : IEntityTypeConfiguration<Opening>
    {
        public void Configure(EntityTypeBuilder<Opening> builder)
        {
            builder.HasData(
                new Opening
                {
                    Id = 1,
                    Title = "New Vancancy",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.",
                    DateCreated = DateTime.Now,
                    DateExpiration = DateTime.Now.AddDays(10),
                    OpeningType = OpeningType.Valid,
                    CompanyEmployeeId = 1
                },
                new Opening
                {
                    Id = 2,
                    Title = "New Vancancy 2",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.",
                    DateCreated = DateTime.Now,
                    DateExpiration = DateTime.Now.AddDays(25),
                    OpeningType = OpeningType.Valid,
                    CompanyEmployeeId = 3
                }
            );
        }
    }
}
