﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Responses
{
    public class BaseCommandResponses
    {
        public string? Id { get; set; }
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
    }
}
