using HireManagment.Application.Contracts.Persistence;
using HireManagment.Domain;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Test.Mocks
{
    public class MockCompanyRepository
    {
        public static Mock<ICompanyRepository> GetCompanyRepository()
        {
            var companies = new List<Company>
            {
                new Company
                {
                    Id = 1,
                    Name = "Naughty Dog",
                    Description = "company 1",
                    Address = "address",
                    AdminId = "1"
                },
                new Company
                {
                    Id = 2,
                    Name = "Riot Games",
                    Description = "company 2",
                    Address = "address",
                    AdminId = "2"
                }
            };

            var mockRepo = new Mock<ICompanyRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(companies);
            mockRepo.Setup(r => r.Get(1)).ReturnsAsync(companies[0]);

            mockRepo.Setup(r => r.Add(It.IsAny<Company>())).ReturnsAsync((Company company) =>
            {
                companies.Add(company);
                return company;
            });

            return mockRepo;

        }
    }
}
