using HireManagment.Application.Constants;
using HireManagment.Application.Contracts.Identity;
using HireManagment.Application.Models.Identity;
using HireManagment.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Persistence.Service
{
    public class AdminApiAuthService : IAuthService
    {
        private readonly HireManagmentDbContext _dbContext;
        private readonly JwtSettings _jwtSettings;

        public AdminApiAuthService(HireManagmentDbContext dbContext, IOptions<JwtSettings> jwtSettings)
        {
            _dbContext = dbContext;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var hasher = new PasswordHasher<AdminApi>();
            var user = await _dbContext.Admins.Where(a => a.Email == request.Email && a.PasswordHash == request.Password).FirstAsync();

            if (user == null)
            {
                throw new Exception($"User with {request.Email} not found.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

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

        private async Task<JwtSecurityToken> GenerateToken(AdminApi user)
        {
            var userClaims = new List<Claim>();
            userClaims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.FirstName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }
            .Union(userClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}
