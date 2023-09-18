using System.ComponentModel.DataAnnotations;

namespace AutoDealer.Entities.Models.Auto
{
    public enum FuelType
    {
        Petrol,
        Diesel
    }
    public class Engine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        [EnumDataType(typeof(FuelType))]
        public required FuelType FuelType { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public required int HorsePower { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public required double Capacity { get; set; }

        public List<Model> Models { get; set; } = new List<Model>();
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}