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
    public class GetOpeningListRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IOpeningRepository> _mockRepo;
        public GetOpeningListRequestHandlerTest()
        {
            _mockRepo = MockOpeningRepository.GetOpeningRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetOpeningListTest()
        {
            var handler = new GetOpeningListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetOpeningListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<OpeningListDto>>();

            result.Count.ShouldBe(1);
        }
    }
}
