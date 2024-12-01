using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data.Reviews;

namespace MovieApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Reviewer)                    // Reviewer navigation property
                .WithMany()                                 // Assuming Reviewer can have many Reviews
                .HasForeignKey(r => r.ReviewerId)           // The foreign key property
                .IsRequired();                              // Specify whether ReviewerId is required
        }
    }
}
