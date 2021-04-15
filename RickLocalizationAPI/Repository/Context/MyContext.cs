using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;

namespace Repository
{

    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<Morty> Morty { get; set; }
        public DbSet<Rick> Rick { get; set; }
        public DbSet<Dimension> Dimension { get; set; }
        public DbSet<RickDimension> RickDimension { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rick>()
                .HasOne(r => r.Morty)
                .WithOne()
                .HasForeignKey<Morty>(m => m.Id);

            modelBuilder.Entity<Morty>()
                .HasOne(m => m.Rick)
                .WithOne(r => r.Morty)
                .HasForeignKey<Rick>(r => r.Id)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RickDimension>().HasKey(rd => new { rd.RickId, rd.DimensionId });

            modelBuilder.Entity<RickDimension>()
                .HasOne<Rick>(rd => rd.Rick)
                .WithMany(r => r.RickDimensions)
                .HasForeignKey(rd => rd.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RickDimension>()
             .HasOne<Dimension>(rd => rd.Dimension)
             .WithMany(d => d.RickDimensions)
             .HasForeignKey(rd => rd.Id)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Seed();

        }

    }


    public class DataSeeder
    {

    }


}
