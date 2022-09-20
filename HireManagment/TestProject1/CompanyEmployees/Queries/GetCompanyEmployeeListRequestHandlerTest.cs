using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.CompanyEmployee;
using HireManagment.Application.Features.CompanyEmployees.Handler.Queries;
using HireManagment.Application.Features.CompanyEmployees.Request.Queries;
using HireManagment.Application.Profiles;
using HireManagment.Test.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Test.CompanyEmployees.Queries
{
    public class GetCompanyEmployeeListRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICompanyEmployeeRepository> _mockRepo;
        public GetCompanyEmployeeListRequestHandlerTest()
        {
            _mockRepo = MockCompanyEmployeeRepository.GetCompanyEmployeeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GeCandidateListTest()
        {
            var handler = new GetCompanyEmployeeListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetCompanyEmployeeListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<CompanyEmployeeListDto>>();

            result.Count.ShouldBe(2);
        }
    }
}
