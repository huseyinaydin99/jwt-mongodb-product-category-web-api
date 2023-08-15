using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ProductWebAPI.Models
{
    public class BuildToken
    {
        public string CreateToken()
        {
            var bytes = Encoding.UTF8.GetBytes("casgemproje11huseyin99");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
    }
}