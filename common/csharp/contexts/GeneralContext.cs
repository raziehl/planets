using Microsoft.EntityFrameworkCore;
using common.models;

public class GeneralContext: DbContext {
  public DbSet<CrewMember> CrewMembers { get; set; } = default!;
  public DbSet<Crew> Crews { get; set; } = default!;
  public DbSet<Planet> Planets { get; set; } = default!;
  public DbSet<Expedition> Expeditions { get; set; } = default!;

  public String DbPath { get; }

  public GeneralContext() 
  {
    DbPath = System.IO.Path.Join("", Environment.GetEnvironmentVariable("DB_PATH"));
  }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlite($"Data Source={DbPath}");
}