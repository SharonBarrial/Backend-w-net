using Carpio.Domain.HR.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace Carpio.Infrastructure.Shared.Contexts;

/// <summary>
/// Represents the Entity Framework database context for the HR module,
/// providing access to the Plans entities stored in the database.
/// </summary>
public class HrContext : DbContext
{
    public HrContext() {}
    /// <summary>
    /// Initializes a new instance of the <see cref="HrContext"/> with the specified options.
    /// The options are typically configured in the startup class of the application.
    /// </summary>
    /// <param name="options">The options to be used by the DbContext.</param>
    public HrContext(DbContextOptions<HrContext> options) : base(options) {}
    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> of Plans, representing the collection of all Plans
    /// in the context, or that can be queried from the database.
    /// </summary>
    public DbSet<JoinRequest> Plans { get; set; }
    
    /// <summary>
    /// Configures the database context options. If the options have not been configured,
    /// it sets up the connection to the MySQl database with the specified server version.
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=12345678;Database=carpio;",
                serverVersion);
        }
    }
    
    /// <summary>
    /// Configures the entity mappings for the JoinRequest entity.
    /// It sets the table name, primary key, required fields and value generation for ID field.
    /// </summary>

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<JoinRequest>().ToTable("JoinRequests");
        modelBuilder.Entity<JoinRequest>().HasKey(p => p.Id);
        modelBuilder.Entity<JoinRequest>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<JoinRequest>().Property(p => p.Name).IsRequired();
        modelBuilder.Entity<JoinRequest>().Property(p => p.DepartmentId).IsRequired();
        modelBuilder.Entity<JoinRequest>().Property(p => p.DesiredJobTitle).IsRequired();
        modelBuilder.Entity<JoinRequest>().Property(p => p.ResumeUrl).IsRequired();
        modelBuilder.Entity<JoinRequest>().Property(p => p.CreatedDate);
        modelBuilder.Entity<JoinRequest>().Property(p => p.UpdatedDate);
    }
}