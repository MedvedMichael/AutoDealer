using AutoDealer.Entities.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDealer.Entities.Configuration
{

    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        private const string ViewerId = "2301D884-221A-4E7D-B509-0113DCC043E1";
        private const string SellerId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";
        private const string ManagerId = "78A7570F-3CE5-48BA-9461-80283ED1D94D";
        private const string AdminId = "01B168FE-810B-432D-9010-233BA0B380E9";

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = ViewerId,
                    Name = Role.Viewer,
                    NormalizedName = Role.Viewer.ToUpper()
                },
                new IdentityRole
                {
                    Id = SellerId,
                    Name = Role.Seller,
                    NormalizedName = Role.Seller.ToUpper()
                },
                new IdentityRole
                {
                    Id = ManagerId,
                    Name = Role.Manager,
                    NormalizedName = Role.Manager.ToUpper()
                },
                new IdentityRole
                {
                    Id = AdminId,
                    Name = Role.Administrator,
                    NormalizedName = Role.Administrator.ToUpper()
                }
        );
        }
    }
}