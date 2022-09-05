using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Company;
using HireManagment.Application.Features.Admin.Request.Queries;
using HireManagment.Application.Features.Company.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HireManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyListDto>>> Get()
        {
            var admins = await _mediator.Send(new GetCompanyListRequest());
            return Ok(admins);
        }
    }
}
