using Microsoft.EntityFrameworkCore;
using PTC_NET_Backend.Models;

namespace PTC_NET_Backend.Data;

public class PtcDbContext : DbContext
{
    public PtcDbContext()
    {
        
    }
    
    public PtcDbContext(DbContextOptions<PtcDbContext> options) : base(options) { }

    public virtual DbSet<WebInfo> WebInfo { get; set; }
    
    public virtual DbSet<Mood> Moods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mood>()
            .Property(b => b.Deleted)
            .HasDefaultValue(false);
        
        modelBuilder.Entity<Question>()
            .Property(b => b.Deleted)
            .HasDefaultValue(false);
    }
}