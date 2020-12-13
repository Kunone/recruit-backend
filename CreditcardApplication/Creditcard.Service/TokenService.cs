using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Creditcard.Service
{
    public class TokenService : ITokenService
    {
        //TODO: mock a login user, later should move to register controller
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            {
                "username", "password"
            }
        };

        private readonly string _key = "this is testing jwt secret key";

        public TokenService()
        {

        }

        public string Authenticate(string username, string password)
        {
            if (!users.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }

            var claims = new Claim[]
            {
                //TODO: fake username and user id, must be move to register controller and get from database
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, "AEEDE1E9-38A4-496F-B213-4FE3B51E9CE3"),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddHours(2)).ToUnixTimeSeconds().ToString())
            };

            var token = new JwtSecurityToken(
                new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
                        SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
