using Application.IRepositories.IUserRepositories;
using Domain._DomainException;
using Domain._DomainValueObjects;
using Domain.RoleAgg.RoleEntity;
using Domain.UserAgg.UserEntity;
using Infrastructure.Context.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Webgostar.Framework.Base.BaseExtensions;
using Webgostar.Framework.Base.SecurityTools;
using Webgostar.Framework.Infrastructure.InfrastructureExtentisions;

namespace Infrastructure.Repository.Repositories.UserRepositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(EfContext context, IRepositoryServices repositoryServices, IConfiguration configuration, IUnitOfWork unitOfWork) : base(context, repositoryServices)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ExistUser(string username)
        {
            try
            {
                return await Table().AnyAsync(x => x.UserName == username);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> Login(PhoneNumber userName, string password)
        {
            try
            {
                var user = await base.Table()
                    .IncludeQueryable(x => x.Roles)
                    .AsTracking()
                    .FirstOrDefaultAsync(x => x.UserName == userName);

                if (user == null) throw new InvalidDomainDataException("رمزعبور یا نام کاربری اشتباه است");

                var dateNow = DateTime.Now.Ticks;

                if (user.LockoutEnd != null && user.LockoutEnd.Value > dateNow && user.LockoutEnabled == true)
                {
                    await _unitOfWork.SaveChangesAsync(CancellationToken.None);
                    throw new InvalidDomainDataException(
                        $"حساب کاربری شما به دلیل ورود های نامعتبر مکرر تا تاریخ {new DateTime(user.LockoutEnd.Value).ToShamsiWhitTime()} مسدود می باشد");
                }

                var passwordHash = Hasher.HashPassword(userName, password);

                if (passwordHash != user.Password)
                {
                    if (user.AccessFailedCount == 5)
                    {
                        user.LoginLock(DateTime.Now.AddMinutes(10).Ticks);
                    }

                    if (user.AccessFailedCount is > 5 and < 10)
                    {
                        user.LoginLock(DateTime.Now.AddHours(3).Ticks);
                    }

                    if (user.AccessFailedCount >= 10)
                    {
                        user.LoginLock(DateTime.Now.AddHours(24).Ticks);
                    }

                    user.LoginFailed();

                    await _unitOfWork.SaveChangesAsync(CancellationToken.None);

                    throw new InvalidDomainDataException("نام کاربری یا رمز عبور اشتباه است");
                }

                user.LoginSuccess();

                await _unitOfWork.SaveChangesAsync(CancellationToken.None);

                var userRoleList = user.Roles.ToList();

                var accessToken = await CreateToken(user, userRoleList);

                return accessToken;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> RefreshToken(string token)
        {
            try
            {
                var claims = await GetClaimList(token, false);

                var userId = claims.FirstOrDefault(x => x.Type == "Id")!.Value;

                var user = await base.Table()
                    .Include(x => x.Roles)
                    .AsTracking().FirstOrDefaultAsync(x => x.Id == long.Parse(userId));

                var userRoleList = user.Roles.ToList();

                var accessToken = await CreateToken(user, userRoleList);

                return accessToken;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User?> ValidateCredentialsAsync(PhoneNumber userName, string password)
        {
            try
            {
                var user = await base.Table()
                    .IncludeQueryable(x => x.Roles)
                    .AsTracking()
                    .FirstOrDefaultAsync(x => x.UserName == userName);

                if (user == null) throw new InvalidDomainDataException("رمزعبور یا نام کاربری اشتباه است");

                var dateNow = DateTime.Now.Ticks;

                if (user.LockoutEnd != null && user.LockoutEnd.Value > dateNow && user.LockoutEnabled == true)
                {
                    await _unitOfWork.SaveChangesAsync(CancellationToken.None);
                    throw new InvalidDomainDataException(
                        $"حساب کاربری شما به دلیل ورود های نامعتبر مکرر تا تاریخ {new DateTime(user.LockoutEnd.Value).ToShamsiWhitTime()} مسدود می باشد");
                }

                var passwordHash = Hasher.HashPassword(userName, password);

                if (passwordHash != user.Password)
                {
                    if (user.AccessFailedCount == 5)
                    {
                        user.LoginLock(DateTime.Now.AddMinutes(10).Ticks);
                    }

                    if (user.AccessFailedCount is > 5 and < 10)
                    {
                        user.LoginLock(DateTime.Now.AddHours(3).Ticks);
                    }

                    if (user.AccessFailedCount >= 10)
                    {
                        user.LoginLock(DateTime.Now.AddHours(24).Ticks);
                    }

                    user.LoginFailed();

                    await _unitOfWork.SaveChangesAsync(CancellationToken.None);

                    throw new InvalidDomainDataException("نام کاربری یا رمز عبور اشتباه است");
                }

                user.LoginSuccess();

                await _unitOfWork.SaveChangesAsync(CancellationToken.None);

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<string> CreateToken(User user, List<Role> userRoles)
        {
            try
            {
                ClaimsIdentity identity = new([
                    new Claim("Id", user.Id.ToString()),
                    new Claim("UserName", user.UserName),
                    new Claim("FullName", user.FullName),
                    new Claim("UserGuid", user.Guid.ToString()),
                    new Claim("PersonId", user.Id.ToString())
                ]);

                var roleFirst = userRoles.FirstOrDefault();

                Claim roleClaim = new("RoleId", roleFirst.Id.ToString()!);

                identity.AddClaim(roleClaim);

                JArray roleGuids = [];
                JArray roleLongs = [];

                foreach (var role in userRoles)
                {
                    JObject jObject = new()
                    {
                        ["RoleGuid"] = role.Guid
                    };

                    JObject jObjectId = new()
                    {
                        ["RoleId"] = role?.Id
                    };

                    roleGuids.Add(jObject);
                    roleLongs.Add(jObjectId);
                }

                Claim claimGuids = new("RolesGuid", JsonConvert.SerializeObject(roleGuids));
                Claim claimRoles = new("RolesId", JsonConvert.SerializeObject(roleLongs));

                identity.AddClaim(claimGuids);
                identity.AddClaim(claimRoles);

                return await WriteToken(identity);
            }
            catch (Exception e)
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
            catch (Exception e)
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
