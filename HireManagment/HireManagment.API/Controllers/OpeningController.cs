using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Opening;
using HireManagment.Application.Features.Admins.Request.Commands;
using HireManagment.Application.Features.Admins.Request.Queries;
using HireManagment.Application.Features.Openings.Request.Command;
using HireManagment.Application.Features.Openings.Request.Queries;
using HireManagment.Application.Responses;
using HireManagment.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HireManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpeningController : Controller
    {
        private readonly IMediator _mediator;

        public OpeningController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee,Candidate")]
        public async Task<ActionResult<List<OpeningListDto>>> Get()
        {
            var admins = await _mediator.Send(new GetOpeningListRequest());
            return Ok(admins);
        }

        [HttpGet("{openingId}")]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult<OpeningDto>> Get(int openingId)
        {
            var admin = await _mediator.Send(new GetOpeningRequest { OpeningId = openingId });
            return Ok(admin);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult<BaseCommandResponses>> Post([FromBody] CreateOpeningDto opening)
        {
            var command = new CreateOpeningCommand { CreateOpening = opening };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult> Put([FromBody] UpdateOpeningDto opening)
        {
            var command = new UpdateOpeningCommand { Opening = opening };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{openingId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult> Delete(int openingId)
        {
            var command = new DeleteOpeningCommand { Id = openingId };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
