
namespace AutoDealer.Entities.DataTransferObjects.Auth
{
    public class RegistrationResponseDto
    {
        public IEnumerable<string>? Errors { get; set; }
        public string? Token { get; set; }
        public UserProfile? User { get; set; }
    }
}