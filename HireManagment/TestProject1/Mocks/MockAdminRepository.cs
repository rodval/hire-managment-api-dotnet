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
    public class MockAdminRepository
    {
        public static Mock<IAdminRepository> GetAdminRepository()
        {
            var hasher = new PasswordHasher<AdminApi>();

            var admins = new List<AdminApi>
            {
                new AdminApi
                {
                    Id = "1",
                    FirstName = "test1",
                    LastName = "Strange",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                },
                new AdminApi
                {
                    Id = "2",
                    FirstName = "test2",
                    LastName = "Dario",
                    Age = 32,
                    Email = "candidate2@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword2")
                }
            };

            var mockRepo = new Mock<IAdminRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(admins);
            mockRepo.Setup(r => r.Get("1")).ReturnsAsync(admins[0]);

            mockRepo.Setup(r => r.Add(It.IsAny<AdminApi>())).ReturnsAsync((AdminApi admin) =>
            {
                admins.Add(admin);
                return admin;
            });

            return mockRepo;

        }
    }
}
