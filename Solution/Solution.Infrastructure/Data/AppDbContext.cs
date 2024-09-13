

using Microsoft.EntityFrameworkCore;
using Solution.Domain.Entity;

namespace Solution.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<PlaceCategory> Categories { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Place>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Places)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Place>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Places);
        }
    }
}
