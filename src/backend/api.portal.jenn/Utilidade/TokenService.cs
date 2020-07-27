using api.portal.jenn.Contract;
using api.portal.jenn.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System; 
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace api.portal.jenn.Utilidade
{

    
    public class TokenService: ITokenService
    {
        private readonly IConfiguration Configuration;
        public TokenService(IConfiguration _configuration)
        {
            this.Configuration = _configuration;
        }
        public string GenerateToken(ConsultaLogonViewModel model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("JwtConfig:Secret"));
            var expirationInMinutes = Configuration.GetValue<string>("JwtConfig:expirationInMinutes");


            var tokenDescriptor = new SecurityTokenDescriptor
            {

              

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, model.Nome.ToString()),
                    new Claim(ClaimTypes.Role, model.Papeis.SingleOrDefault().Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(Double.Parse(expirationInMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
