using Microsoft.EntityFrameworkCore;
using AuthorAPI.Models;

namespace AuthorAPI.Data
{
    public class AuthorDbContext : DbContext
    {
        public AuthorDbContext(DbContextOptions<AuthorDbContext> options) : base(options) { }

        public DbSet<AuthorAPI.Models.Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorAPI.Models.Author>(entity =>
            {
                entity.HasKey(e => e.AuthorId);
                entity.Property(e => e.NameEn).HasMaxLength(100).IsRequired();
                entity.Property(e => e.NameTa).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Role).HasMaxLength(20).HasDefaultValue("Writer");
            });
        }
    }
}