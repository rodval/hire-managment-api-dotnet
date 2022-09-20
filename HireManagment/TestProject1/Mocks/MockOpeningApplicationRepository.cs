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
    public class MockOpeningApplicationRepository
    {
        public static Mock<IOpeningApplicationRepository> GetOpeningApplicationRepository()
        {
            var applications = new List<OpeningApplication>
            {
                new OpeningApplication
                {
                    Id = 1,
                    DateApplication = DateTime.Now,
                    Status = ApplicationStatusType.InProcess,
                    CompanyEmployeeId = "1",
                    CandidateId = "1"
                }
            };

            var mockRepo = new Mock<IOpeningApplicationRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(applications);
            mockRepo.Setup(r => r.Get("1")).ReturnsAsync(applications[0]);

            mockRepo.Setup(r => r.Add(It.IsAny<OpeningApplication>())).ReturnsAsync((OpeningApplication application) =>
            {
                applications.Add(application);
                return application;
            });

            return mockRepo;

        }
    }
}
