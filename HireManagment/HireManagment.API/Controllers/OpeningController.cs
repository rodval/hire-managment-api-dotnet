using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HireManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpeningController : Controller
    {
        private readonly IMediator _mediator;

        public OpeningController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
