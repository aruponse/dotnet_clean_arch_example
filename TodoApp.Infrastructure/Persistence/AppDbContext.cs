// TodoApp.Infrastructure/Persistence/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;

namespace TodoApp.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Tarea> Tasks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>()
            .Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(100);
    }
}