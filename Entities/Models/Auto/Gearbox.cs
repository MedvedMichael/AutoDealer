using System.ComponentModel.DataAnnotations;

namespace AutoDealer.Entities.Models.Auto
{
    public enum GearboxType
    {
        Manual,
        Automatic,
        Variator,
        Robotic
    }
    public class Gearbox
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        [EnumDataType(typeof(GearboxType))]
        public required GearboxType GearboxType { get; set; }

        public List<Engine> Engines { get; set; } = new List<Engine>();
    }
}