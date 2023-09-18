using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDealer.Entities.DataTransferObjects.Auto
{
    public class BaseAutoDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}