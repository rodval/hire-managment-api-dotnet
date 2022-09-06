using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Admins.Request.Commands
{
    public class DeleteAdminCommand : IRequest
    {
        public int Id { get; set; }
    }
}
