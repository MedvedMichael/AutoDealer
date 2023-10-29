using System.ComponentModel.DataAnnotations;
using AutoDealer.Entities.DataTransferObjects.Auth;

namespace AutoDealer.Entities.DataTransferObjects.Auto
{
    public class Car
    {
        [Required]
        public required BaseAutoDto Brand { get; set; }

        [Required]
        public required BaseAutoDto Model { get; set; }

        [Required]
        public required GenerationDto Generation { get; set; }

        [Required]
        public required EngineDto Engine { get; set; }

        [Required]
        public required BaseAutoDto Equipment { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public required int Year { get; set; }

        [Required]
        public required string Color { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public required int OwnersCount { get; set; }

        [Required]
        public required string WinNumber { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public required int Mileage { get; set; }
    }

    public class SaleAnnouncementDto
    {
        [Required]
        public required int Id { get; set; }

        [Required]
        public required Car Car { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public required int Price { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        public required UserProfile Owner { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public required DateTime CreatedAt { get; set; }

    }
}