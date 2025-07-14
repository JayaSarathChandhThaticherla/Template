using Microsoft.EntityFrameworkCore;
using Server.Models; // Ensure this is included for your UserTable model

namespace Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for your UserTable entity, which will map to the UserDetails table
        public DbSet<UserTable> UserTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Explicit Configuration for UserTable Entity ---
            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(u => u.Id); // Explicitly sets Id as primary key
                entity.Property(u => u.FirstName)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(u => u.LastName)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.HasIndex(u => u.Email) // Creates a unique index on the Email column
                      .IsUnique(); // Ensures no two users can have the same email in the database
                entity.Property(u => u.Password)
                      .HasMaxLength(255); // Ensures sufficient length for a hashed password
            });
        }
    }
}
