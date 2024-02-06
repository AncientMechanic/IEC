using Domain.Views;
using Infrastructure.Exceptions;
using Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EF.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ProjectContext _context;
        private readonly ISecurityProvider _securityProvider;

        public AuthRepository(ProjectContext context, ISecurityProvider securityProvider)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _securityProvider = securityProvider ?? throw new ArgumentNullException(nameof(securityProvider));
        }

        public async Task<string> CreateToken(AuthView model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                throw new ArgumentNullException(nameof(model.Email));
            }

            var userExist = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == model.Email);

            if (userExist is null)
            {
                throw new NotFoundException($"User '{model.Email}' not found.");
            }

            if (userExist.Password != model.Password)
            {
                throw new UnauthorizedException($"Password incorrect.");
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Email, model.Email) };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityProvider.SecurityKey));

            var jwt = new JwtSecurityToken(
                    issuer: _securityProvider.ISSUER,
                    audience: _securityProvider.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(_securityProvider.ExpireTime),
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
