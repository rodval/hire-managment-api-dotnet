using HireManagment.Application.Constants;
using HireManagment.Application.Contracts.Identity;
using HireManagment.Application.Models.Identity;
using HireManagment.Domain;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AdminApi> _userManager;
        private readonly SignInManager<AdminApi> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AdminApiAuthService(UserManager<AdminApi> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<AdminApi> signInManager)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception($"User with {request.Email} not found.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.Email, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new Exception($"Credentials for '{request.Email} aren't valid'.");
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
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.FirstName),
                new Claim(JwtRegisteredClaimNames.Sub, user.LastName),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

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
