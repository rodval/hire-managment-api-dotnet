using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Opening;
using HireManagment.Application.Features.Openings.Handlers.Queries;
using HireManagment.Application.Features.Openings.Request.Queries;
using HireManagment.Application.Profiles;
using HireManagment.Test.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Test.Openings.Queries
{
    public class GetOpeningRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IOpeningRepository> _mockRepo;

        public GetOpeningRequestHandlerTest()
        {
            _mockRepo = MockOpeningRepository.GetOpeningRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetOpeningTest()
        {
            var handler = new GetOpeningRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetOpeningRequest() { OpeningId = 1 }, CancellationToken.None);

            result.ShouldBeOfType<OpeningDto>();
            result.Id.ShouldBe(1);
        }
    }
}
