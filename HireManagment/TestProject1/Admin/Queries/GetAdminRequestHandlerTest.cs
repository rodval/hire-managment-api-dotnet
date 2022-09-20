using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.Features.Admins.Handlers.Queries;
using HireManagment.Application.Features.Admins.Request.Queries;
using HireManagment.Application.Profiles;
using HireManagment.Test.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Test.Admin.Queries
{
    public class GetAdminRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAdminRepository> _mockRepo;

        public GetAdminRequestHandlerTest()
        {
            _mockRepo = MockAdminRepository.GetAdminRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCandidateTest()
        {
            var handler = new GetAdminRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetAdminRequest() { AdminId = "1" }, CancellationToken.None);

            result.ShouldBeOfType<AdminApiDto>();
            result.Id.ShouldBe("1");
        }
    }
}
