using System.ComponentModel.DataAnnotations;

namespace AutoDealer.Entities.DataTransferObjects.Auth
{
    public class RegisterDto : LoginDto
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Surname { get; set; }
    }
}