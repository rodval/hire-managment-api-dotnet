﻿using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.CompanyEmployee;
using HireManagment.Application.Features.Admins.Request.Commands;
using HireManagment.Application.Features.Admins.Request.Queries;
using HireManagment.Application.Features.Companies.Request.Commands;
using HireManagment.Application.Features.CompanyEmployees.Request.Commands;
using HireManagment.Application.Features.CompanyEmployees.Request.Queries;
using HireManagment.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HireManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyEmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public CompanyEmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyEmployeeListDto>>> Get()
        {
            var employee = await _mediator.Send(new GetCompanyEmployeeListRequest());
            return Ok(employee);
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<CompanyEmployeeDto>> Get(int employeeId)
        {
            var employee = await _mediator.Send(new GetCompanyEmployeeRequest { CompanyEmployeeId = employeeId });
            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponses>> Post([FromBody] CreateCompanyEmployeeDto employee)
        {
            var command = new CreateCompanyEmployeeCommand { CreateEmployee = employee };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}