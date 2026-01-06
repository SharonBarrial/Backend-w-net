using Microsoft.EntityFrameworkCore;

namespace _3_Data.Contexts;

public class LearningCenterContext :DbContext
{
    public LearningCenterContext()
    {
        
    }
    
    public LearningCenterContext(DbContextOptions<LearningCenterContext> options) : base(options)
    {
        
    }
    
    public DbSet<Tutorial> Tutorials { get; set; }
    public DbSet<Section> Section { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Conexión a la base de datos
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MariaDbServerVersion(new Version(8, 0, 36));
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=12345678;Database=LearningCenterWS52DB;", serverVersion);
        }
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
       base.OnModelCreating(builder);

       //FLUENT API
       //Mapeo de la tabla Tutorial a la tabla Tutorial
       //Esto es para que la tabla Tutorial se llame Tutorial en la base de datos
       builder.Entity<Tutorial>().ToTable("Tutorial");
       //builder.Entity<Tutorial>().HasKey(p => p.Id);
       
                                    //Properties configuration
       //builder.Entity<Tutorial>().Property(p => p.Name).IsRequired().HasMaxLength(25);
       
       builder.Entity<Section>().ToTable("Section");
       
       //
    }
}