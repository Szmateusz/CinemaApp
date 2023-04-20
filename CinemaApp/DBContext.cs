using CinemaApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CinemaApp
{  
        public class DBContext : IdentityDbContext<UserModel>
        {
            public DBContext(DbContextOptions<DBContext> options) : base(options) { }

            public DbSet<MovieModel> Movies { get; set; }
            
            public DbSet<HallModel> Halls { get; set; }
            public DbSet<ActorModel> Actors { get; set; }
            public DbSet<ReviewModel> Reviews { get; set; }
            public DbSet<ScheduleModel> Schedules { get; set; }
            public DbSet<ReservationModel> Reservations { get; set; }
            public DbSet<UserModel> Users { get; set; }
          
            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

            builder.Entity<ScheduleModel>()
                .HasOne(h => h.Hall)
                .WithMany(s => s.Schedules)
                .HasForeignKey(h => h.HallID);

            builder.Entity<ScheduleModel>()
               .HasOne(h => h.Movie)
               .WithMany()
               .HasForeignKey(h => h.MovieID);

            builder.Entity<ActorModel>()
               .HasMany(m => m.Movies)
               .WithMany(a => a.Actors);

            builder.Entity<ReviewModel>()
               .HasOne(m => m.Movie)
               .WithMany(f => f.Reviews)
               .HasForeignKey(r => r.MovieID);

            builder.Entity<ReservationModel>()
                .HasOne(h => h.Seance)
                .WithMany(s => s.Reservations)
                .HasForeignKey(h => h.SeanceID);

        }

        }
    
}
