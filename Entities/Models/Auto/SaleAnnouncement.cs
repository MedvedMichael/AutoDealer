using System.ComponentModel.DataAnnotations;
using AutoDealer.Entities.Models.Auth;

namespace AutoDealer.Entities.Models.Auto
{
    public class SaleAnnouncement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required Model Model { get; set; }

        public Generation? Generation { get; set; }

        public Engine? Engine { get; set; }

        public Equipment? Equipment { get; set; }

        public Gearbox? Gearbox { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public required int Price { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public required int OwnersCount { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public required int MileageThousands { get; set; }

        [Required]
        public required User User { get; set; }
    }
}