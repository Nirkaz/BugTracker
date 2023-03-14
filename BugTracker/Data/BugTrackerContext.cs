using BugTracker.Data.JoiningEntities;
using BugTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data;

public class BugTrackerContext : IdentityDbContext<User>
{
    public DbSet<Bug> Bugs { get; set; }
    public override DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public BugTrackerContext(DbContextOptions<BugTrackerContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BugWatchers>(entity =>
        {
            entity.HasKey(k => new { k.BugId, k.UserId });

            entity.HasOne(o => o.Bug)
                .WithMany(m => m.BugWatchers)
                .HasForeignKey(fk => fk.BugId)
                .IsRequired(false);

            entity.HasOne(o => o.User)
                .WithMany(m => m.WatchedBugs)
                .HasForeignKey(fk => fk.UserId)
                .IsRequired(false);
        });

        modelBuilder.Entity<Bug>(entity => 
        {
            entity.ToTable("Bugs");

            entity.HasOne(o => o.Reporter)
                .WithMany(m => m.CreatedBugs)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(o => o.Assignee)
                .WithMany(m => m.AssignedBugs)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(m => m.Comments).WithOne(o => o.Bug);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasMany(m => m.Comments).WithOne(o => o.Author);
        });

        modelBuilder.Entity<Comment>().ToTable("Comments");
    }
}
