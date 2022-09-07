using HireManagment.Application.Contracts.Identity;
using HireManagment.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HireManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAuthService _authenticationService;

        public AccountController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }
    }
}
