using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Domain;
using Microsoft.AspNetCore.Identity;

namespace TestProject1.Mocks
{
    public class MockCandidateRepository
    {
        public static Mock<ICandidateRepository> GetCandidateRepository()
        {
            var hasher = new PasswordHasher<Candidate>();

            var candidates = new List<Candidate>
            {
                new Candidate
                {
                    Id = "1",
                    FirstName = "test1",
                    LastName = "Strange",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                },
                new Candidate
                {
                    Id = "2",
                    FirstName = "test2",
                    LastName = "Dario",
                    Age = 32,
                    Email = "candidate2@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword2")
                }
            };

            var mockRepo = new Mock<ICandidateRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(candidates);

            mockRepo.Setup(r => r.Add(It.IsAny<Candidate>())).ReturnsAsync((Candidate candidate) =>
            {
                candidates.Add(candidate);
                return candidate;
            });

            return mockRepo;

        }
    }
}
