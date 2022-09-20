using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Candidate;
using HireManagment.Application.Features.Candidates.Handlers.Queries;
using HireManagment.Application.Features.Candidates.Request.Queries;
using HireManagment.Application.Profiles;
using HireManagment.Test.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Test.Candidates.Queries
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
        public async Task GeCandidateListTest()
        {
            var handler = new GetCandidateListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetCandidateListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<CandidateListDto>>();

            result.Count.ShouldBe(2);
        }
    }
}
