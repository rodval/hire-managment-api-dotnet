using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Company;
using HireManagment.Application.Features.Companies.Handlers.Queries;
using HireManagment.Application.Features.Companies.Request.Queries;
using HireManagment.Application.Profiles;
using HireManagment.Test.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Test.Companies.Queries
{
    public class GetCompanyRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICompanyRepository> _mockRepo;

        public GetCompanyRequestHandlerTest()
        {
            _mockRepo = MockCompanyRepository.GetCompanyRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCompanyTest()
        {
            var handler = new GetCompanyRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetCompanyRequest() { CompanyId = 1 }, CancellationToken.None);

            result.ShouldBeOfType<CompanyDto>();
            result.Id.ShouldBe(1);
        }
    }
}
