using Microsoft.EntityFrameworkCore;
using theatre_booking.DataAccess.models;

namespace theatre_booking.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the one-to-one relationship between Event and Theatre
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Theatre)
                .WithOne(t => t.Event)
                .HasForeignKey<Event>(e => e.TheatreId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Theatre>()
                .HasOne(t => t.Event)
                .WithOne(e => e.Theatre)
                .HasForeignKey<Theatre>(t => t.EventId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Theatre-Seat relationship
            modelBuilder.Entity<Seat>()
                .HasOne(s => s.theatre)
                .WithMany(t => t.Seats)
                .HasForeignKey(s => s.TheatreId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure User-Seat relationship
            modelBuilder.Entity<Seat>()
                .HasOne(s => s.user)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<models.User> Users { get; set; }
        public DbSet<models.Seat> Seats { get; set; }
        public DbSet<models.Theatre> Theatres { get; set; }
        public DbSet<models.Event> Events { get; set; }
    }
}
