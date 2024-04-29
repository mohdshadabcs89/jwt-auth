namespace jwt_token.Model.JwtResponse
{
    public class JwtResponse
    {
        public string UserName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public int Status { get; set; } 
    }
}
