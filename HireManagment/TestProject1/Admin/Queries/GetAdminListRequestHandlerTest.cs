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
    public class GetAdminListRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAdminRepository> _mockRepo;
        public GetAdminListRequestHandlerTest()
        {
            _mockRepo = MockAdminRepository.GetAdminRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GeCandidateListTest()
        {
            var handler = new GetAdminListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetAdminListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<AdminApiListDto>>();

            result.Count.ShouldBe(2);
        }
    }
}
