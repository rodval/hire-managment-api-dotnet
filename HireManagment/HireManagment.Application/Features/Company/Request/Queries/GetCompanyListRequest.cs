﻿using HireManagment.Application.DTOs.Company;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Company.Request.Queries
{
    public class GetCompanyListRequest : IRequest<List<CompanyListDto>>
    {
    }
}
