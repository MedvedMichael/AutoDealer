using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDealer.Entities.Models.Auto
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required Model Model { get; set; }

        [Required]
        public required Generation Generation { get; set; }

        [Required]
        public required Engine Engine { get; set; }

        public List<SaleAnnouncement> SaleAnnouncements { get; set; } = new List<SaleAnnouncement>();
    }
}