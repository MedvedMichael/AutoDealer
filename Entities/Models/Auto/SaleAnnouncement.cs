using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoDealer.Entities.Models.Auth;

namespace AutoDealer.Entities.Models.Auto
{
    public class SaleAnnouncement
    {
        [Key]
        public int Id { get; set; }

        public Model? Model { get; set; }

        [Required]
        [ForeignKey("Model")]
        public int ModelId { get; set; }

        public Generation? Generation { get; set; }

        [Required]
        [ForeignKey("Generation")]
        public int GenerationId { get; set; }

        public Engine? Engine { get; set; }

        [Required]
        [ForeignKey("Engine")]
        public int EngineId { get; set; }

        public Equipment? Equipment { get; set; }

        [Required]
        [ForeignKey("Equipment")]
        public int EquipmentId { get; set; }

        public Gearbox? Gearbox { get; set; }

        [Required]
        [ForeignKey("Gearbox")]
        public int GearboxId { get; set; }

        [Required]
        [Range(1900, int.MaxValue)]
        public required int Year { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public required int Price { get; set; }

        [Required]
        public required string Color { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public required int OwnersCount { get; set; }

        [Required]
        public required string WinNumber { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public required int MileageThousands { get; set; }

        public User? User { get; set; }

        [Required]
        [ForeignKey("User")]
        public required string UserId { get; set; }

        [Required]
        public required string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}