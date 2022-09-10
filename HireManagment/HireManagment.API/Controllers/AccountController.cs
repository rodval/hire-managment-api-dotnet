using HireManagment.Application.Contracts.Identity;
using HireManagment.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HireManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAdminApiAuthService _adminApiAuthService;
        private readonly ICandidateAuthService _candidateAuthService;
        private readonly ICompanyEmployeeAuthService _companyEmployeeAuthService;

        public AccountController(IAdminApiAuthService adminApiAuthService, ICandidateAuthService candidateAuthService, ICompanyEmployeeAuthService companyEmployeeAuthService)
        {
            _adminApiAuthService = adminApiAuthService;
            _candidateAuthService = candidateAuthService;
            _companyEmployeeAuthService = companyEmployeeAuthService;
        }

        [HttpPost("admin/login")]
        public async Task<ActionResult<AuthResponse>> LoginAdmin(AuthRequest request)
        {
            return Ok(await _adminApiAuthService.Login(request));
        }

        [HttpPost("employe/login")]
        public async Task<ActionResult<AuthResponse>> LoginEmployee(AuthRequest request)
        {
            return Ok(await _companyEmployeeAuthService.Login(request));
        }

        [HttpPost("candidate/login")]
        public async Task<ActionResult<AuthResponse>> LoginCandidate(AuthRequest request)
        {
            return Ok(await _candidateAuthService.Login(request));
        }
    }
}
