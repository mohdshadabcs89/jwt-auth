using jwt_token.Model.JwtRequest;
using jwt_token.Model.JwtResponse;

namespace jwt_token.Auth
{
    public interface IGenerateJwtToken
    {
        Task<JwtResponse> GenerateTokenAsync(JwtRequest jwtRequest);
    }
}
