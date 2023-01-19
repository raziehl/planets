using Microsoft.EntityFrameworkCore;
using crews_api.models;

public class CrewsContext: DbContext {
  public DbSet<CrewMember> CrewMembers { get; set; } = default!;

  public String DbPath { get; }

  public CrewsContext() 
  {
    DbPath = System.IO.Path.Join("", Environment.GetEnvironmentVariable("DB_PATH"));
  }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlite($"Data Source={DbPath}");
}