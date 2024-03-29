﻿using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Candidate;
using HireManagment.Application.Features.Admins.Request.Commands;
using HireManagment.Application.Features.Admins.Request.Queries;
using HireManagment.Application.Features.Candidates.Request.Commands;
using HireManagment.Application.Features.Candidates.Request.Queries;
using HireManagment.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HireManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : Controller
    {
        private readonly IMediator _mediator;

        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult<List<CandidateListDto>>> Get()
        {
            var admins = await _mediator.Send(new GetCandidateListRequest());
            return Ok(admins);
        }

        [HttpGet("{candidateId}")]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee,Candidate")]
        public async Task<ActionResult<CandidateDto>> Get(string candidateId)
        {
            var admin = await _mediator.Send(new GetCandidateRequest { CandidateId = candidateId });
            return Ok(admin);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public async Task<ActionResult<BaseCommandResponses>> Post([FromBody] CreateCandidateDto candidate)
        {
            var command = new CreateCandidateCommand { CreateCandidate = candidate };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee,Candidate")]
        public async Task<ActionResult> Put([FromBody] UpdateCandidateDto candidate)
        {
            var command = new UpdateCandidateCommand { Candidate = candidate };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{candidateId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult> Delete(string candidateId)
        {
            var command = new DeleteCandidateCommand { Id = candidateId };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
