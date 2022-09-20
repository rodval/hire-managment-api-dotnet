using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.OpeningApplication;
using HireManagment.Application.Features.Admins.Handlers.Queries;
using HireManagment.Application.Features.Admins.Request.Queries;
using HireManagment.Application.Features.OpeningApplications.Handler.Queries;
using HireManagment.Application.Features.OpeningApplications.Request.Queries;
using HireManagment.Application.Profiles;
using HireManagment.Test.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Test.OpeningApplications.Queries
{
    public class GetOpeningApplicationListRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IOpeningApplicationRepository> _mockRepo;
        public GetOpeningApplicationListRequestHandlerTest()
        {
            _mockRepo = MockOpeningApplicationRepository.GetOpeningApplicationRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetApplicationListTest()
        {
            var handler = new GetOpeningApplicationListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetOpeningApplicationListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<OpeningApplicationListDto>>();

            result.Count.ShouldBe(1);
        }
    }
}
