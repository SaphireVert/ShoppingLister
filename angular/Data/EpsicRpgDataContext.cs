
using Microsoft.EntityFrameworkCore;

public class EpsicRpgDataContext : DbContext
{
    public DbSet<Character> Characters { get; set; }

    public EpsicRpgDataContext(DbContextOptions<EpsicRpgDataContext> options)
        : base(options)
    {
            
    }
}

