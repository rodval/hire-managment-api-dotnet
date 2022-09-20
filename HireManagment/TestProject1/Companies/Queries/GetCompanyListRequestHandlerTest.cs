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
    public class GetCompanyListRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICompanyRepository> _mockRepo;
        public GetCompanyListRequestHandlerTest()
        {
            _mockRepo = MockCompanyRepository.GetCompanyRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GeCompanyListTest()
        {
            var handler = new GetCompanyListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetCompanyListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<CompanyListDto>>();

            result.Count.ShouldBe(2);
        }
    }
}
