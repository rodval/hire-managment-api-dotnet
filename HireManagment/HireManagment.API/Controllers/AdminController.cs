using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.Features.Admin.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}

