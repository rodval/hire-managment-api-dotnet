using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.CompanyEmployee;
using HireManagment.Application.Features.CompanyEmployees.Handler.Commands;
using HireManagment.Application.Features.CompanyEmployees.Request.Commands;
using HireManagment.Application.Profiles;
using HireManagment.Application.Responses;
using HireManagment.Domain.Utilities;
using HireManagment.Domain;
using HireManagment.Test.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Test.CompanyEmployees.Command
{
    public class CreateCompanyEmployeeCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateCompanyEmployeeDto _employeeDto;
        private readonly CreateCompanyEmployeeCommandHandler _handler;

        public CreateCompanyEmployeeCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateCompanyEmployeeCommandHandler(_mockUow.Object, _mapper);

            _employeeDto = new CreateCompanyEmployeeDto
            {
                FirstName = "Brook",
                LastName = "Bane",
                Age = 32,
                Email = "employee2@gmail.com",
                Password = "P@ssword1",
                EmployeeType = EmployeeType.Employee,
                CompanyId = 1
            };
        }

        [Fact]
        public async Task CreateEmployeeTest()
        {
            var result = await _handler.Handle(new CreateCompanyEmployeeCommand() { CreateEmployee = _employeeDto }, CancellationToken.None);

            var admins = await _mockUow.Object.CompanyEmployeeRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponses>();

            admins.Count.ShouldBe(3);
        }
    }
}
