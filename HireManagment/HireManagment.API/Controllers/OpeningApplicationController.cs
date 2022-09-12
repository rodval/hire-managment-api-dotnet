using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.OpeningApplication;
using HireManagment.Application.Features.Admins.Request.Commands;
using HireManagment.Application.Features.Admins.Request.Queries;
using HireManagment.Application.Features.OpeningApplications.Request.Command;
using HireManagment.Application.Features.OpeningApplications.Request.Queries;
using HireManagment.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HireManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    [Authorize(Roles = "CompanyAdmin")]
    [Authorize(Roles = "Employee")]
    public class OpeningApplicationController : Controller
    {
        private readonly IMediator _mediator;

        public OpeningApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<OpeningApplicationListDto>>> Get()
        {
            var admins = await _mediator.Send(new GetOpeningApplicationListRequest());
            return Ok(admins);
        }

        [HttpGet("{applicationId}")]
        public async Task<ActionResult<OpeningApplicationDto>> Get(int applicationId)
        {
            var admin = await _mediator.Send(new GetOpeningApplicationRequest { OpeningApplicationId = applicationId });
            return Ok(admin);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Candidate")]
        public async Task<ActionResult<BaseCommandResponses>> Post([FromBody] CreateOpeningApplicationDto application)
        {
            var command = new CreateOpeningApplicationCommand { CreateOpeningApplication = application };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{applicationId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromBody] UpdateOpeningApplicationDto application)
        {
            var command = new UpdateOpeningApplicationCommand { OpeningApplication = application };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{applicationId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int applicationId)
        {
            var command = new DeleteOpeningApplicationCommand { Id = applicationId };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
