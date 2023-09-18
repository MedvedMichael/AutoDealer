using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoDealer.Entities.Models.Auto
{
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        public Brand? Brand { get; set; }

        public List<Generation> Generations { get; set; } = new List<Generation>();
        public List<Engine> Engines { get; set; } = new List<Engine>();
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}