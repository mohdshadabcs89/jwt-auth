namespace jwt_token.Model.JwtRequest
{
    public class JwtRequest
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; }=string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
