using System.ComponentModel.DataAnnotations;

namespace AutoDealer.Entities.DataTransferObjects.Auto
{
    public class GenerationDto : BaseAutoDto
    {
        [Required]
        public required int StartYear { get; set; }

        public int? EndYear { get; set; }

    }
}