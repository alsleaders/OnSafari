using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnSafari
{
  public partial class SafariContext : DbContext
  {
    public SafariContext()
    {
    }

    public SafariContext(DbContextOptions<SafariContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseNpgsql("server=localhost;database=Safari;User Id=postgres;Password=postgres");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");
    }
    public DbSet<SeenAnimals> Animals { get; set; }
  }
}
