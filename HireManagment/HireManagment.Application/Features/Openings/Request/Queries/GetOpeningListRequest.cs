using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Opening;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Openings.Request.Queries
{
    public class GetOpeningListRequest : IRequest<List<OpeningListDto>>
    {
    }
}
