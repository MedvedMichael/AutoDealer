using System.ComponentModel.DataAnnotations;
using AutoDealer.Entities.Models.Auto;

namespace AutoDealer.Entities.DataTransferObjects.Auto
{
    public class GearboxDto : BaseAutoDto
    {
        [Required]
        public required GearboxType Type { get; set; }
    }
}