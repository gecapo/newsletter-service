using Microsoft.EntityFrameworkCore;
using Newsletter.Domain.Entities;

namespace Newsletter.Domain;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NewsletterOnboardingSagaData>().HasKey(s => s.CorrelationId);
    }

    public DbSet<Subscriber> Subscribers { get; set; }

    public DbSet<NewsletterOnboardingSagaData> SagaData { get; set; }
}
