using Application.IRepositories.IUserRepositories;
using Domain.UserAgg.UserEntity;
using Domain.UserAgg.UserRoleEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Repository.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        public UserManager<User> UserManager { get; set; }
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(IConfiguration configuration, IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            UserManager = userManager;
        }

        public async Task<bool> ExistUser(string username)
        {
            try
            {
                return await UserManager.Users.AnyAsync(x => x.UserName == username);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<string> CreateToken(User user, List<UserRole> userRoles)
        {
            try
            {
                ClaimsIdentity identity = new([
                    new Claim("Id", user.Id),
                    new Claim("UserName", user.UserName),
                    new Claim("FullName", user.FullName)
                ]);

                var roleFirst = userRoles.FirstOrDefault();

                Claim roleClaim = new("RoleId", roleFirst?.Role?.Id);

                identity.AddClaim(roleClaim);

                JArray roleLongs = [];

                foreach (var role in userRoles)
                {
                    JObject jObjectId = new()
                    {
                        ["RoleId"] = role.Role?.Id
                    };

                    roleLongs.Add(jObjectId);
                }

                Claim claimRoles = new("RolesId", JsonConvert.SerializeObject(roleLongs));

                identity.AddClaim(claimRoles);

                return await WriteToken(identity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<string> WriteToken(ClaimsIdentity claims)
        {
            try
            {
                var expiresMinutes = int.Parse(_configuration["JwtConfig:ExpireToken"]!);

                JwtSecurityTokenHandler jwtTokenHandler = new();

                SymmetricSecurityKey signingKey = new(
                    Encoding.UTF8.GetBytes(_configuration["JwtConfig:SignInKey"]!));

                SigningCredentials signingCredentials = new(signingKey, SecurityAlgorithms.HmacSha256);

                SecurityTokenDescriptor jwt = new()
                {
                    SigningCredentials = signingCredentials,
                    Subject = claims,
                    Issuer = _configuration["JwtConfig:Issuer"],
                    Audience = _configuration["JwtConfig:Audience"],
                    Expires = DateTime.UtcNow.AddMinutes(expiresMinutes)
                };

                var token = jwtTokenHandler.CreateToken(jwt);

                return jwtTokenHandler.WriteToken(token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<List<Claim>> GetClaimList(string? token, bool IsValidate = true)
        {
            if (string.IsNullOrEmpty(token)) return null;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:SignInKey"] ?? string.Empty));
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["JwtConfig:Issuer"],
                ValidAudience = _configuration["JwtConfig:Audience"],
                IssuerSigningKey = securityKey
            };

            try
            {
                if (IsValidate)
                {
                    tokenHandler.ValidateToken(token, validationParameters, out _);
                }

                if (tokenHandler.ReadToken(token) is JwtSecurityToken jsonToken)
                {
                    return jsonToken.Claims.ToList();
                }
            }
            catch (Exception)
            {
                return [];
            }

            return null;
        }
    }
}
