using HireManagment.Application.Contracts.Identity;
using HireManagment.Application.Models.Identity;
using HireManagment.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Persistence.Service
{
    public class CompanyEmployeeAuthService : AuthService, ICompanyEmployeeAuthService
    {
        private readonly HireManagmentDbContext _dbContext;

        public CompanyEmployeeAuthService(HireManagmentDbContext dbContext, IOptions<JwtSettings> jwtSettings) : base(jwtSettings)
        {
            _dbContext = dbContext;
        }

        public override async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _dbContext.CompanyEmployees.Where(a => a.Email == request.Email).FirstAsync();
            var hasherPassword = new PasswordHasher<AdminApi>().VerifyHashedPassword(null, user.PasswordHash, request.Password);

            if (user == null || hasherPassword == PasswordVerificationResult.Failed)
            {
                throw new Exception($"User with {request.Email} not found.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = request.Email,
                Role = "Administrator"
            });

            AuthResponse response = new AuthResponse
            {
                Id = Int32.Parse(user.Id),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return response;
        }
    }
}
