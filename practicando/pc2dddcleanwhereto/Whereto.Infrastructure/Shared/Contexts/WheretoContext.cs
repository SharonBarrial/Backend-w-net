using Microsoft.EntityFrameworkCore;
using Whereto.Domain.Booking.Models.Entities;

namespace Whereto.Infrastructure.Shared.Contexts;

public class WheretoContext: DbContext
{
    public WheretoContext()
    {
        
    }

    public WheretoContext(DbContextOptions<WheretoContext> options) : base(options)
    {
        
    }
    
    public DbSet<Domain.Booking.Models.Entities.Booking> Bookings { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=12345678;Database=whereto;",
                serverVersion);
        }
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Domain.Booking.Models.Entities.Booking>().ToTable("Bookings");
        builder.Entity<Domain.Booking.Models.Entities.Booking>().HasKey(p => p.Id);
        builder.Entity<Domain.Booking.Models.Entities.Booking>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Domain.Booking.Models.Entities.Booking>().Property(p => p.Username).IsRequired();
        builder.Entity<Domain.Booking.Models.Entities.Booking>().Property(p => p.RouteId).IsRequired();
        builder.Entity<Domain.Booking.Models.Entities.Booking>().Property(p => p.Days).IsRequired();
        builder.Entity<Domain.Booking.Models.Entities.Booking>().Property(p => p.Comments);
        builder.Entity<Domain.Booking.Models.Entities.Booking>().Property(p => p.CreatedAt).IsRequired();
    }
}