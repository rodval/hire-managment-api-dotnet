using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Candidate;
using HireManagment.Application.Features.Candidates.Handlers.Queries;
using HireManagment.Application.Features.Candidates.Request.Queries;
using HireManagment.Application.Profiles;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Mocks;

namespace TestProject1.Candidates.Queries
{
    public class GetCandidateListRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICandidateRepository> _mockRepo;
        public GetCandidateListRequestHandlerTest()
        {
            _mockRepo = MockCandidateRepository.GetCandidateRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetCandidateListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetCandidateListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<CandidateListDto>>();

            result.Count.ShouldBe(2);
        }
    }
}
