using ControleMaquinasMx_Domain.Entities;
using ControleMaquinasMx_Manager.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControleMaquinasMx_Data.Services
{
    public class JWTServices : IJWTService
    {
        private readonly IConfiguration _configuration;

        public JWTServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GerarToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            //PESQUISAR SOBRE ARMAZENAMENTO DE SEGREDOS/SENHAS NA NUVEM (ATUALMENTE UTILIZANDO NO APPSETTINGS [NAO RECOMENDADO])
            var chave = Encoding.ASCII.GetBytes(_configuration.GetSection("JWT:Secret").Value);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login)
            };
            claims.AddRange(user.Permissao.Select(x => new Claim(ClaimTypes.Role, x.Descricao)));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = _configuration.GetSection("JWT:Audience").Value,
                Issuer = _configuration.GetSection("JWT:Issuer").Value,
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration.GetSection("JWT:ExpiraEmMinutos").Value)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
