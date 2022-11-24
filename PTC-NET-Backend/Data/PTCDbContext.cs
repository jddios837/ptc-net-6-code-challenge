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
    
    public DbSet<Question> Question { get; set; }
    
    public DbSet<User> Users { get; set; }

    public DbSet<UserMood> UserMoods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mood>()
            .Property(b => b.Deleted)
            .HasDefaultValue(false);
        
        modelBuilder.Entity<Question>()
            .Property(b => b.Deleted)
            .HasDefaultValue(false);
        
        modelBuilder.Entity<User>()
            .Property(b => b.Deleted)
            .HasDefaultValue(false);

        // USER MOOD DEFINITIONS AND RESTRICTIONS
        modelBuilder.Entity<UserMood>()
            .HasOne(p => p.User)
            .WithMany(b => b.UserMoods)
            .HasForeignKey(p => p.DriverId);

        modelBuilder.Entity<UserMood>()
            .HasOne(p => p.Mood)
            .WithMany(b => b.UserMoods)
            .HasForeignKey(p => p.MoodId);
        
        modelBuilder.Entity<UserMood>()
            .HasOne(p => p.User)
            .WithMany(b => b.UserMoods)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<UserMood>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId);
        
        modelBuilder.Entity<UserMood>()
            .HasOne(p => p.User)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }

    
}