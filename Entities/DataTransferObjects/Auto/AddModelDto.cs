using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDealer.Entities.DataTransferObjects.Auto
{
    public class ModelDto
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public required int BrandId { get; set; }
        public List<string> Generations { get; set; } = new List<string>();
    }
}