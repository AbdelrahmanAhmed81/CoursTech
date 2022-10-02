
namespace Application.DataModels
{
    public class AuthResponse
    {
        public string Email { get; set; } = "";
        public string Token { get; set; } = "";
        public DateTime Expiration { get; set; }
    }
}
