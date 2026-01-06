using Microsoft.EntityFrameworkCore;

namespace si730pc2u202114900.Infrastructure.Shared.Contexts;

public class HrContext: DbContext
{
    public HrContext(){}
    
    public HrContext(DbContextOptions<HrContext> options) : base(options)
    {
    }
    public DbSet<JoinRequest>
}