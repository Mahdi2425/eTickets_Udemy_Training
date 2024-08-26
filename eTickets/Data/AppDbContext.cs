using eTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace eTickets.Data

{
        public class AppDbContext : IdentityDbContext<ApplicationUser>
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.MovieId,
                am.ActorId
            });
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);
            modelBuilder.Entity<Cinema>().HasMany(c => c.Movies).WithOne(m => m.Cinema).HasForeignKey(m => m.CinemaId);
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShopingCartItem> shopingCartItems { get; set; }

    }
}
