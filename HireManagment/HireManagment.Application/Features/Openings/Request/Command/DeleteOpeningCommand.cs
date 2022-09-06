﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Openings.Request.Command
{
    public class DeleteOpeningCommand : IRequest
    {
        public int Id { get; set; }
    }
}
