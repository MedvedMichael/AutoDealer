using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoDealer.Entities.Models.Auto.IntermediateModels
{
    public class EngineGearbox
    {
        [Required]
        [ForeignKey(nameof(Engine.Id))]
        public required int EnginesId { get; set; }

        [Required]
        [ForeignKey(nameof(Gearbox))]
        public required int GearboxesId { get; set; }
    }
}