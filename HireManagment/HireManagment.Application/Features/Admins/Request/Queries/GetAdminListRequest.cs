﻿using HireManagment.Application.DTOs.Admin;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Admins.Request.Queries
{
    public class GetAdminListRequest : IRequest<List<AdminApiListDto>>
    {
    }
}
