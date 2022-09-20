using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Candidate;
using HireManagment.Application.Features.Candidates.Handlers.Queries;
using HireManagment.Application.Features.Candidates.Request.Queries;
using HireManagment.Application.Profiles;
using HireManagment.Domain;
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
    public class GetCandidateRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICandidateRepository> _mockRepo;

        public GetCandidateRequestHandlerTest()
        {
            _mockRepo = MockCandidateRepository.GetCandidateRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCandidateTest()
        {
            var handler = new GetCandidateRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetCandidateRequest() { CandidateId = "1" } , CancellationToken.None);

            result.ShouldBeOfType<CandidateDto>();
            result.Id.ShouldBe("1");
        }
    }
}
