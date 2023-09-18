
namespace AutoDealer.Entities.DataTransferObjects.Auth
{
    public class AuthResponseDto
    {
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public UserProfile? User { get; set; }
    }
}