using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Company;
using HireManagment.Application.Features.Admins.Request.Commands;
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

        [HttpPut("{adminId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromBody] UpdateCompanyDto company)
        {
            var command = new UpdateCompanyCommand { Company = company };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{adminId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int companyId)
        {
            var command = new DeleteCompanyCommand { Id = companyId };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
