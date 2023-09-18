using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AutoDealer.Entities.Configuration;
using AutoDealer.Entities.Models.Auth;
using AutoDealer.Entities.Models.Auto;

namespace AutoDealer.Data
{
    public class AutoDbContext : IdentityDbContext<User>
    {
        public AutoDbContext(DbContextOptions<AutoDbContext> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Generation> Generations { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<SaleAnnouncement> SaleAnnouncements { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            modelBuilder.ApplyConfiguration(new GenerationConfiguration());
            modelBuilder.ApplyConfiguration(new EngineConfiguration());

            modelBuilder.Entity<Model>().HasOne(m => m.Brand).WithMany(b => b.Models);
            modelBuilder.Entity<Model>().HasMany(m => m.Engines).WithMany(m => m.Models);
            modelBuilder.Entity<Model>().HasMany(m => m.Generations).WithOne(g => g.Model);
            modelBuilder.Entity<Car>().HasMany(c => c.SaleAnnouncements).WithOne(s => s.Car);
            modelBuilder.Entity<Car>().HasOne(c => c.Model).WithMany(m => m.Cars).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Car>().HasOne(c => c.Generation).WithMany(g => g.Cars).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Car>().HasOne(c => c.Engine).WithMany(e => e.Cars).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Car>().HasMany(c => c.SaleAnnouncements).WithOne(s => s.Car);
        }
    }
}