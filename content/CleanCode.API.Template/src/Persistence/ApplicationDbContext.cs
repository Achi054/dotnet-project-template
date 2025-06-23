using Microsoft.EntityFrameworkCore;

namespace Custom.Persistence;
public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
    {
            
    }
}
