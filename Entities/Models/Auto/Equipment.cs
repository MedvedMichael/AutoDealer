using System.ComponentModel.DataAnnotations;

namespace AutoDealer.Entities.Models.Auto
{
    public class Equipment
    {
        [Required]
        public required int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public List<Model> Models { get; set; } = new List<Model>();
        public List<SaleAnnouncement> SaleAnnouncements { get; set; } = new List<SaleAnnouncement>();
    }
}