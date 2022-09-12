using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.CompanyEmployee;
using HireManagment.Application.Features.Admins.Request.Commands;
using HireManagment.Application.Features.Admins.Request.Queries;
using HireManagment.Application.Features.Companies.Request.Commands;
using HireManagment.Application.Features.CompanyEmployees.Request.Commands;
using HireManagment.Application.Features.CompanyEmployees.Request.Queries;
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
        [Authorize(Roles = "CompanyAdmin")]
        public async Task<ActionResult<CompanyEmployeeDto>> Get(string employeeId)
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

        [HttpPut("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "CompanyAdmin")]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult> Put([FromBody] UpdateCompanyEmployeeDto employee)
        {
            var command = new UpdateCompanyEmployeeCommand { Employee = employee };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string employeeId)
        {
            var command = new DeleteCompanyEmployeeCommand { Id = employeeId };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
