using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.OpeningApplication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.OpeningApplications.Request.Queries
{
    public class GetOpeningApplicationListRequest : IRequest<List<OpeningApplicationListDto>>
    {
    }
}
