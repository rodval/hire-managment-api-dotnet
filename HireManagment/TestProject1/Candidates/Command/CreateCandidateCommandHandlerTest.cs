using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Candidate;
using HireManagment.Application.Features.Candidates.Handlers.Commands;
using HireManagment.Application.Features.Candidates.Request.Commands;
using HireManagment.Application.Profiles;
using HireManagment.Application.Responses;
using HireManagment.Domain;
using HireManagment.Test.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Test.Candidates.Command
{
    public class CreateCandidateCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateCandidateDto _candidateDto;
        private readonly CreateCandidateCommandHandler _handler;

        public CreateCandidateCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateCandidateCommandHandler(_mockUow.Object, _mapper);

            _candidateDto = new CreateCandidateDto
            {
                FirstName = "Robert",
                LastName = "Wade",
                Age = 32,
                Email = "rodrigovalladares1@gmail.com",
                Password = "P@ssword1"
            };
        }

        [Fact]
        public async Task CreateCandidateTest()
        {
            var result = await _handler.Handle(new CreateCandidateCommand() { CreateCandidate = _candidateDto }, CancellationToken.None);

            var leaveTypes = await _mockUow.Object.CandidateRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponses>();

            leaveTypes.Count.ShouldBe(3);
        }
    }
}
