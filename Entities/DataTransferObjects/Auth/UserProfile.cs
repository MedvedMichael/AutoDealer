using System.ComponentModel.DataAnnotations;

namespace AutoDealer.Entities.DataTransferObjects.Auth
{
    public class UserProfile
    {
        [Required]
        public required string Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Surname { get; set; }

        [Required]
        public required string Email { get; set; }
    }
}