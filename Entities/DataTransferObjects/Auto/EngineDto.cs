using System.ComponentModel.DataAnnotations;
using AutoDealer.Entities.Models.Auto;

namespace AutoDealer.Entities.DataTransferObjects.Auto
{
    public class EngineDto : BaseAutoDto
    {
        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        public double Capacity { get; set; }

        [Required]
        public int HorsePower { get; set; }
    }
}