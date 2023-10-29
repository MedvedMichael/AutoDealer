using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoDealer.Entities.Models.Auto.IntermediateModels
{
    public class EquipmentModel
    {
        [Required]
        [ForeignKey(nameof(Equipment))]
        public required int EquipmentsId { get; set; }

        [Required]
        [ForeignKey(nameof(Model))]
        public required int ModelsId { get; set; }

    }
}