using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.OpeningApplication;
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
    public class GetOpeningApplicationRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IOpeningApplicationRepository> _mockRepo;

        public GetOpeningApplicationRequestHandlerTest()
        {
            _mockRepo = MockOpeningApplicationRepository.GetOpeningApplicationRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCandidateTest()
        {
            var handler = new GetOpeningApplicationRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetOpeningApplicationRequest() { OpeningApplicationId = 1 }, CancellationToken.None);

            result.ShouldBeOfType<OpeningApplicationDto>();
            result.Id.ShouldBe(1);
        }
    }
}
