using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.OpeningApplication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.OpeningApplications.Request.Queries
{
    public class GetOpeningApplicationRequest : IRequest<OpeningApplicationDto>
    {
        public int OpeningApplicationId { get; set; }
    }
}
