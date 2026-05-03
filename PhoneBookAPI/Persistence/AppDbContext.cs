using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Phone> Phones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Phone>().HasIndex(ph => ph.PhoneNumber).IsUnique();
        modelBuilder.Entity<Phone>().HasOne(ph => ph.User).WithMany(u => u.Phones).HasForeignKey(ph => ph.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}