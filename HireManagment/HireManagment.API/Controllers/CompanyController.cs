using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Company;
using HireManagment.Application.Features.Companies.Request.Commands;
using HireManagment.Application.Features.Companies.Request.Queries;
using HireManagment.Application.Responses;
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

        [HttpGet("{companyId}")]
        public async Task<ActionResult<CompanyDto>> Get(int companyId)
        {
            var admin = await _mediator.Send(new GetCompanyRequest { CompanyId = companyId });
            return Ok(admin);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponses>> Post([FromBody] CreateCompanyDto company)
        {
            var command = new CreateCompanyCommand { CreateCompany = company };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
