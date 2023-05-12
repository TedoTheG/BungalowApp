using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BungalowApp.Data;
using Microsoft.Build.Evaluation;

namespace BungalowApp.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<BungalowApp.Data.ReservationList>? ReservationList { get; set; }
    public DbSet<BungalowApp.Data.Bungalow>? Bungalow { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<ReservationList>()
        .HasMany(rl => rl.Bungalows)
        .WithOne(br => br.ReservationList)
        .OnDelete(DeleteBehavior.NoAction);
      base.OnModelCreating(builder);
    }
  }
}