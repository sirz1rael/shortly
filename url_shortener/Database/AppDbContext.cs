using Microsoft.EntityFrameworkCore;
using url_shortener.Models;

namespace url_shortener.Database
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        // User Table
        public DbSet<User> Users { get; set; }
        // Urls Table
        public DbSet<Url> Urls { get; set; }
        // Roles table
        public DbSet<Role> Roles { get; set; }

        // Clicks Table
        public DbSet<Click> Clicks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relations and constraints
            modelBuilder.Entity<User>() // One role to Many Users
                .HasOne(u => u.Role)
                .WithMany(r => r.AssignedTo)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Url>() // Many Urls to One User
                .HasOne(u => u.Creator)
                .WithMany(r => r.CreatedUrls)
                .HasForeignKey(u => u.CreatorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Click>() // Many Clicks to One Url
                .HasOne(c => c.Url)
                .WithMany(r => r.Clicks)
                .HasForeignKey(c => c.UrlId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>() // Seed Roles
                .HasData(
                    new Role { Id = 1, Role_Type = "USER" },
                    new Role { Id = 2, Role_Type = "USER_PREMIUM" },
                    new Role { Id = 3, Role_Type = "USER_ADMIN" }
                );

            // Entity configurations
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.PublicId);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(200);
                entity.Property(e => e.PublicId).IsRequired().HasMaxLength(64);
                entity.Property(e => e.RoleId).IsRequired().HasDefaultValue(0);

                entity.HasIndex(e => e.PublicId).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<Url>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OriginalUrl).IsRequired().HasMaxLength(2000);
                entity.Property(e => e.ShortCode).IsRequired().HasMaxLength(10);
                
                entity.HasIndex(e => e.ShortCode).IsUnique();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Role_Type).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Click>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IPAddress).HasMaxLength(45);
                entity.Property(e => e.UserAgent).HasMaxLength(512);
            });
        }
    }
}
