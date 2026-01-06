using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730pc2u20221c936.API.HR.Domain.Model.Aggregates;
using si730pc2u20221c936.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace si730pc2u20221c936.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<JoinRequest> JoinRequests { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Human Resources Context
        builder.Entity<JoinRequest>()
            .HasIndex(jr => new { jr.Name, jr.DepartmentId })
            .IsUnique();
        builder.Entity<JoinRequest>().HasKey(jr => jr.Id);
        builder.Entity<JoinRequest>().Property(jr => jr.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<JoinRequest>().Property(jr => jr.Name).IsRequired().HasMaxLength(100);
        builder.Entity<JoinRequest>().Property(jr => jr.DepartmentId).IsRequired();
        builder.Entity<JoinRequest>().Property(jr => jr.DesiredJobTitle).IsRequired().HasMaxLength(100);
        builder.Entity<JoinRequest>().Property(jr => jr.ResumeUrl).IsRequired().HasMaxLength(100);
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}