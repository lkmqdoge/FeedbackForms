using FeedbackForms.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace FeedbackForms.Infrastructure;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Form> Forms { get; set; }

    public DbSet<Topic> Topics { get; set; }

    public DbSet<Answer> Answers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}