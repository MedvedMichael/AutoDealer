using System.ComponentModel.DataAnnotations;
using AutoDealer.Entities.Models.Auto;
using Microsoft.AspNetCore.Identity;

namespace AutoDealer.Entities.Models.Auth
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        [StringLength(50)]
        public required string Surname { get; set; }

        public List<SaleAnnouncement> SaleAnnouncements { get; set; } = new List<SaleAnnouncement>();
    }
}