using HireManagment.Application.Contracts.Persistence;
using HireManagment.Domain;
using HireManagment.Domain.Utilities;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Test.Mocks
{
    public class MockOpeningRepository
    {
        public static Mock<IOpeningRepository> GetAdminRepository()
        {
            var openings = new List<Opening>
            {
                new Opening
                {
                    Id = 1,
                    Title = "New Vancancy",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.",
                    DateCreated = DateTime.Now,
                    DateExpiration = DateTime.Now.AddDays(10),
                    OpeningType = OpeningType.Valid,
                    CompanyEmployeeId = "1"
                }
            };

            var mockRepo = new Mock<IOpeningRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(openings);
            mockRepo.Setup(r => r.Get("1")).ReturnsAsync(openings[0]);

            mockRepo.Setup(r => r.Add(It.IsAny<Opening>())).ReturnsAsync((Opening opening) =>
            {
                openings.Add(opening);
                return opening;
            });

            return mockRepo;

        }
    }
}
