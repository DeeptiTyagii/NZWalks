using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalks.API.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _config;

        //to get info drom appsettings.json we need to inject iconfiguration 
        //using iconfiguration we can access appsettings and we can retrieve valure from there
        public TokenRepository(IConfiguration config)
        {
            _config = config;
        }

        public string CreateJwtToken(IdentityUser user, List<string> roles)
        {
            //Create CLaims
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            //Create token

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires : DateTime.Now.AddMinutes(15),
                signingCredentials : credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
