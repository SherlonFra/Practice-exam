using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies.Models;


namespace Movies.Data
{
    public class ApplicationDbContext:DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().HasKey(sc => new {sc.ActorId, sc.MovieId});
            

            modelBuilder.Entity<MovieActor>()
                .HasOne<Actor>(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.ActorId);

            modelBuilder.Entity<MovieActor>()
                .HasOne<Movie>(ma => ma.Movie)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.MovieId);

   



        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

    }
}
