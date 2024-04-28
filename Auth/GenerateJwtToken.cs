using jwt_token.Model.JwtRequest;
using jwt_token.Model.JwtResponse;

namespace jwt_token.Auth
{
    public class GenerateJwtToken : IGenerateJwtToken
    {
        public async Task<JwtResponse> GenerateTokenAsync(JwtRequest jwtRequest)
        {
            JwtResponse jwtResponse = new JwtResponse();
            return jwtResponse;
        }
    }
}
