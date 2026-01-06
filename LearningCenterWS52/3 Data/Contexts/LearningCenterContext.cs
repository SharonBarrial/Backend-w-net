using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;

namespace _3_Data.Contexts;


public class LearningCenterContext : DbContext
{
    public LearningCenterContext()
    {
        
    }
    
    public LearningCenterContext(DbContextOptions<LearningCenterContext> options) : base(options)
    {
    }
    public DbSet<Tutorial> Tutorials { get; set; }
    public DbSet<Section> Secctions { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 4, 0));
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=#UPC12345;Database=LearningCenterWS52DB;", serverVersion);
        }
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Fluent
        base.OnModelCreating(builder);

        builder.Entity<Tutorial>().ToTable("Tutorial");
        //builder.Entity<Tutorial>().HasKey(p => p.Id);
        //builder.Entity<Tutorial>().Property(p => p.Name).IsRequired().HasMaxLength(25);
        
        builder.Entity<Section>().ToTable("Section");

    }
}