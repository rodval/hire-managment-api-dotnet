using HireManagment.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Test.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();

            var mockCandidateRepo = MockCandidateRepository.GetCandidateRepository();
            var mockAdminRepo = MockAdminRepository.GetAdminRepository();
            var mockCompanyRepo = MockCompanyRepository.GetCompanyRepository();

            var mockCompanyEmployeeRepo = MockCompanyEmployeeRepository.GetCompanyEmployeeRepository();
            var mockOpeningRepo = MockOpeningRepository.GetOpeningRepository();
            var mockOpeningApplicationRepo = MockOpeningApplicationRepository.GetOpeningApplicationRepository();

            mockUow.Setup(r => r.CandidateRepository).Returns(mockCandidateRepo.Object);
            mockUow.Setup(r => r.AdminRepository).Returns(mockAdminRepo.Object);
            mockUow.Setup(r => r.CompanyRepository).Returns(mockCompanyRepo.Object);

            return mockUow;
        }
    }
}
