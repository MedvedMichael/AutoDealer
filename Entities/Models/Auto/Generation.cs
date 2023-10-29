using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoDealer.Entities.Models.Auto
{
    public class Generation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required int StartYear { get; set; }

        public int? EndYear { get; set; }

        [Required]
        [ForeignKey("Model")]
        public required int ModelId { get; set; }

        public Model? Model { get; set; }
        public List<SaleAnnouncement> SaleAnnouncements { get; set; } = new List<SaleAnnouncement>();
    }
}