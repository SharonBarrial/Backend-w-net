using casetravelers.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace casetravelers.Infrastructure.Contexts;

public class TravelerContext : DbContext
{
     public TravelerContext()
     {
     }

     public TravelerContext(DbContextOptions<TravelerContext> options) : base(options)
     {
     }
     
     public DbSet<Destination> Destinations { get; set; }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
          var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
          if (!optionsBuilder.IsConfigured)
          {
               optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=12345678;Database=destination;",
                    serverVersion);
          }
     }

     protected override void OnModelCreating(ModelBuilder builder)
     {
          base.OnModelCreating(builder);

          builder.Entity<Destination>().ToTable("Travels");
          builder.Entity<Destination>().HasKey(p => p.Id);
          builder.Entity<Destination>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
          builder.Entity<Destination>().Property(p => p.Name).IsRequired();
          builder.Entity<Destination>().Property(p => p.MaxUsers).IsRequired();
          builder.Entity<Destination>().Property(p => p.IsRisky).IsRequired();
          
          //builder.Entity<Tutorial>().HasKey(p => p.Id);
          //builder.Entity<Tutorial>().Property(p => p.Name).IsRequired().HasMaxLength(25);
          
     }
}