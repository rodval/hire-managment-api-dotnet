using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Opening;
using HireManagment.Application.Profiles;
using HireManagment.Application.Responses;
using HireManagment.Domain.Utilities;
using HireManagment.Domain;
using HireManagment.Test.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireManagment.Application.Features.Openings.Request.Command;
using HireManagment.Application.Features.Openings.Handlers.Commands;

namespace HireManagment.Test.Openings.Command
{
    public class CreateOpeningRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateOpeningDto _openingDto;
        private readonly CreateOpeningCommandHandler _handler;

        public CreateOpeningRequestHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateOpeningCommandHandler(_mockUow.Object, _mapper);

            _openingDto = new CreateOpeningDto
            {
                Title = "New Vancancy",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.",
                DateCreated = DateTime.Now,
                DateExpiration = DateTime.Now.AddDays(10),
                OpeningType = OpeningType.Valid,
                CompanyEmployeeId = 1
            };
        }

        [Fact]
        public async Task CreateCandidateTest()
        {
            var result = await _handler.Handle(new CreateOpeningCommand() { CreateOpening = _openingDto }, CancellationToken.None);

            var admins = await _mockUow.Object.AdminRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponses>();

            admins.Count.ShouldBe(2);
        }
    }
}
