using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDealer.Entities.Models.Auto.IntermediateModels
{
    public class EngineModel
    {
        [Required]
        [ForeignKey(nameof(Engine))]
        public required int EnginesId { get; set; }

        [Required]
        [ForeignKey(nameof(Model))]
        public required int ModelsId { get; set; }
    }
}