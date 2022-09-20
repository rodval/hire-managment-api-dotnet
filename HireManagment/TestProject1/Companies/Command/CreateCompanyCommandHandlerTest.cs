using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Company;
using HireManagment.Application.Features.Companies.Handlers.Commands;
using HireManagment.Application.Features.Companies.Request.Commands;
using HireManagment.Application.Profiles;
using HireManagment.Application.Responses;
using HireManagment.Domain;
using HireManagment.Test.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Test.Companies.Command
{
    public class CreateCompanyCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateCompanyDto _companyDto;
        private readonly CreateCompanyCommandHandler _handler;

        public CreateCompanyCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateCompanyCommandHandler(_mockUow.Object, _mapper);

            _companyDto = new CreateCompanyDto
            {
                Name = "Naughty Dog",
                Description = "company 1",
                Address = "address",
                AdminId = "1"
            };
        }

        [Fact]
        public async Task CreateCandidateTest()
        {
            var result = await _handler.Handle(new CreateCompanyCommand() { CreateCompany = _companyDto }, CancellationToken.None);

            var companies = await _mockUow.Object.CompanyRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponses>();

            companies.Count.ShouldBe(3);
        }
    }
}
