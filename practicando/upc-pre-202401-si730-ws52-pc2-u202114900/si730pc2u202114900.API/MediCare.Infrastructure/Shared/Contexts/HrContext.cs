using MediCare.Domain.HR.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace MediCare.Infrastructure.Shared.Contexts;

/// <summary>
/// Represents the Entity Framework database context for the HR module,
/// providing access to the Appoinments entities stored in the database.
/// </summary>
public class HrContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HrContext"/> with the specified options.
    /// The options are typically configured in the startup class of the application.
    /// </summary>
    /// <param name="options">The options to be used by the DbContext.</param>
    public HrContext(DbContextOptions<HrContext> options) : base(options) {}
    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> of Appoinments, representing the collection of all Appoinments
    /// in the context, or that can be queried from the database.
    /// </summary>
    public DbSet<Appointment> Appointments { get; set; }
    /// <summary>
    /// Configures the database context options. If the options have not been configured,
    /// it sets up the connection to the MySQl database with the specified server version.
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=12345678;Database=Appointments;",
                serverVersion);
        }
    }
    
    /// <summary>
    /// Configures the entity mappings for the Appoinment entity.
    /// It sets the table name, primary key, required fields and value generation for ID field.
    /// </summary>

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Appointment>().ToTable("Appoinments");
        modelBuilder.Entity<Appointment>().HasKey(p => p.Id);
        modelBuilder.Entity<Appointment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Appointment>().Property(p => p.PatientName).IsRequired();
        modelBuilder.Entity<Appointment>().Property(p => p.DoctorName).IsRequired();
        modelBuilder.Entity<Appointment>().Property(p => p.Email).IsRequired();
        modelBuilder.Entity<Appointment>().Property(p => p.Speciality).IsRequired();
        modelBuilder.Entity<Appointment>().Property(p => p.AppoinmentDate).IsRequired();
        modelBuilder.Entity<Appointment>().Property(p => p.AppoinmentTime).IsRequired();
        modelBuilder.Entity<Appointment>().Property(p => p.CreatedDate);
        modelBuilder.Entity<Appointment>().Property(p => p.UpdatedDate);
    }
    
    
}