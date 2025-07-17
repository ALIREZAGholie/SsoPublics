using Application.IRepositories.IAuthRepositories;
using Application.IRepositories.IUserRepositories;
using Domain.UserAgg.UserEntity;
using Domain.UserAgg.UserRoleEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Repository.Repositories.AuthRepositories
{
    public class TokenService(IUserRepository userManager, IConfiguration configuration)
        : ITokenService
    {
        public async Task<string> GenerateTokenAsync(User user)
        {
            var claims = await userManager.UserManager.GetClaimsAsync(user);

            ClaimsIdentity identity = new([
                new Claim("Id", user.Id.ToString()),
                new Claim("UserName", user.UserName),
                new Claim("FullName", user.FullName)
            ]);

            identity.AddClaims(claims);

            if (user?.UserRoles is { Count: > 0 })
            {
                var roleFirst = user.UserRoles?.FirstOrDefault();

                Claim roleClaim = new("RoleId", roleFirst?.Role?.Id?.ToString());

                identity.AddClaim(roleClaim);

                JArray roleLongs = [];

                foreach (var role in user.UserRoles)
                {
                    JObject jObjectId = new()
                    {
                        ["RoleId"] = role.Role?.Id
                    };
                    roleLongs.Add(jObjectId);
                }

                Claim claimRoles = new("RolesId", JsonConvert.SerializeObject(roleLongs));

                identity.AddClaim(claimRoles);
            }

            var expiresMinutes = int.Parse(configuration["JwtConfig:ExpireToken"]!);

            JwtSecurityTokenHandler jwtTokenHandler = new();

            SymmetricSecurityKey signingKey = new(
                Encoding.UTF8.GetBytes(configuration["JwtConfig:SignInKey"]!));

            SigningCredentials signingCredentials = new(signingKey, SecurityAlgorithms.HmacSha256);

            SecurityTokenDescriptor jwt = new()
            {
                SigningCredentials = signingCredentials,
                Subject = identity,
                Issuer = configuration["JwtConfig:Issuer"],
                Audience = configuration["JwtConfig:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(expiresMinutes)
            };

            var token = jwtTokenHandler.CreateToken(jwt);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<string> CreateToken(User user, List<UserRole> userRoles)
        {
            try
            {
                ClaimsIdentity identity = new([
                    new Claim("Id", user.Id.ToString()),
                    new Claim("UserName", user.UserName),
                    new Claim("FullName", user.FullName)
                ]);

                var roleFirst = userRoles.FirstOrDefault();

                Claim roleClaim = new("RoleId", roleFirst?.Role?.Id.ToString()!);

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
                var expiresMinutes = int.Parse(configuration["JwtConfig:ExpireToken"]!);

                JwtSecurityTokenHandler jwtTokenHandler = new();

                SymmetricSecurityKey signingKey = new(
                    Encoding.UTF8.GetBytes(configuration["JwtConfig:SignInKey"]!));

                SigningCredentials signingCredentials = new(signingKey, SecurityAlgorithms.HmacSha256);

                SecurityTokenDescriptor jwt = new()
                {
                    SigningCredentials = signingCredentials,
                    Subject = claims,
                    Issuer = configuration["JwtConfig:Issuer"],
                    Audience = configuration["JwtConfig:Audience"],
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

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SignInKey"] ?? string.Empty));
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JwtConfig:Issuer"],
                ValidAudience = configuration["JwtConfig:Audience"],
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
