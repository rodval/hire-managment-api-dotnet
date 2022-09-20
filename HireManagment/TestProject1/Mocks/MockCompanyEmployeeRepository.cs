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
    public class MockCompanyEmployeeRepository
    {
        public static Mock<ICompanyEmployeeRepository> GetCompanyRepository()
        {
            var hasher = new PasswordHasher<CompanyEmployee>();

            var employees = new List<CompanyEmployee>
            {
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
                    Email = "employee2@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword2"),
                    EmployeeType = EmployeeType.Employee,
                    CompanyId = 1
                }
            };

            var mockRepo = new Mock<ICompanyEmployeeRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(employees);
            mockRepo.Setup(r => r.Get("1")).ReturnsAsync(employees[0]);

            mockRepo.Setup(r => r.Add(It.IsAny<CompanyEmployee>())).ReturnsAsync((CompanyEmployee employee) =>
            {
                employees.Add(employee);
                return employee;
            });

            return mockRepo;

        }
    }
}
