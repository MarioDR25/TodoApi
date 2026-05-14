
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
     public DbSet<TodoItem> TodoItems { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(e =>
        {
           e.ToTable("TodoItems"); 
           e.HasKey(x => x.Id);
           e.Property(x => x.Id).ValueGeneratedOnAdd();
           e.Property(x => x.Label).IsRequired().HasMaxLength(50);
           e.Property(x => x.IsComplete).HasDefaultValue(false);
           e.Property(x => x.CreatedAt).IsRequired();
        });
    }
}


