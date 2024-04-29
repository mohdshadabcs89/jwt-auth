using jwt_token.Model.Config;
using jwt_token.Model.JwtRequest;
using jwt_token.Model.JwtResponse;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace jwt_token.Auth
{
    public class GenerateJwtToken : IGenerateJwtToken
    {
        private IConfiguration _configuration;
        private readonly Jwt _config;
        public GenerateJwtToken(IConfiguration configuration, IOptions<Jwt> config)
        {
            _configuration = configuration;
            _config = config.Value;
        }
        public JwtResponse GenerateTokenAsync(JwtRequest jwtRequest)
        {
            JwtResponse jwtResponse = new();

            var isUserAuthenticated = Authenticate(jwtRequest);
            if (isUserAuthenticated)
            {
                jwtResponse= GetToken(jwtRequest);
            }

            return jwtResponse;
        }
        private bool Authenticate(JwtRequest jwtRequest)
        {
            if (jwtRequest.UserName == "admin" && jwtRequest.Password == "123")
            {
                return true;
            }
            return false;
        }
        private JwtResponse GetToken(JwtRequest jwtRequest)
        {
            var jwtResponse = new JwtResponse();
            // var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:Key"]));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Key));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //var token = new JwtSecurityToken(_configuration["jwt:Issuer"], _configuration["jwt:Audience"], null,
            //    expires: DateTime.Now.AddMinutes(1),
            //    signingCredentials: credential);

            var token = new JwtSecurityToken(_config.Issuer, _config.Audience, null,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credential);
            jwtResponse.UserName = jwtRequest.UserName;
            jwtResponse.Token = new JwtSecurityTokenHandler().WriteToken(token);
            jwtResponse.Status = StatusCodes.Status200OK;
            return jwtResponse;
        }
    }
}
