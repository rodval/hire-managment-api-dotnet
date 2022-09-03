using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.Features.Admin.Request.Commands;
using HireManagment.Application.Features.Admin.Request.Queries;
using HireManagment.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HireManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdminListDto>>> Get()
        {
            var admins = await _mediator.Send(new GetAdminListRequest());
            return Ok(admins);
        }

        [HttpGet("{adminId}")]
        public async Task<ActionResult<AdminDto>> Get(int adminId)
        {
            var admin = await _mediator.Send(new GetAdminRequest { AdminId = adminId });
            return Ok(admin);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponses>> Post([FromBody] AdminManagmentDto admin)
        {
            var command = new CreateAdminCommand { AdminManagmentDto = admin };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}

