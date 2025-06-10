using Microsoft.EntityFrameworkCore;
using s31367_kolokwium2.Models.Entities;

namespace s31367_kolokwium2.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Map> Maps { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerMatch> PlayerMatches { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var maps = new List<Map>
            {
                new Map { MapId = 1, Name = "Inferno", Type = "Bomb Defusal" },
                new Map { MapId = 2, Name = "Mirage", Type = "Bomb Defusal" },
                new Map { MapId = 3, Name = "Dust II", Type = "Bomb Defusal" }
            };
            modelBuilder.Entity<Map>().HasData(maps);
            
            var tournaments = new List<Tournament>
            {
                new Tournament { TournamentId = 1, Name = "CS2 Summer Cup", StartDate = DateTime.Parse("2025-07-01"), EndDate = DateTime.Parse("2025-07-07") },
                new Tournament { TournamentId = 2, Name = "Pro League Season 1", StartDate = DateTime.Parse("2025-08-01"), EndDate = DateTime.Parse("2025-08-15") }
            };
            modelBuilder.Entity<Tournament>().HasData(tournaments);
            
            var matches = new List<Match>
            {
                new Match { MatchId = 1, TournamentId = 1, MapId = 1, MatchDate = DateTime.Parse("2025-07-02T15:00:00"), Team1Score = 16, Team2Score = 12, BestRating = 1.25m },
                new Match { MatchId = 2, TournamentId = 1, MapId = 2, MatchDate = DateTime.Parse("2025-07-03T18:00:00"), Team1Score = 10, Team2Score = 16, BestRating = 1.32m },
                new Match { MatchId = 3, TournamentId = 2, MapId = 1, MatchDate = DateTime.Parse("2025-08-05T20:00:00"), Team1Score = 16, Team2Score = 8, BestRating = 1.15m }
            };
            modelBuilder.Entity<Match>().HasData(matches);
            
            var players = new List<Player>
            {
                new Player { PlayerId = 1, FirstName = "Alex", LastName = "Smith", BirthDate = DateTime.Parse("2000-05-20") },
                new Player { PlayerId = 2, FirstName = "John", LastName = "Doe", BirthDate = DateTime.Parse("1998-11-10") }
            };
            modelBuilder.Entity<Player>().HasData(players);
            
            var playerMatches = new List<PlayerMatch>
            {
                new PlayerMatch { MatchId = 1, PlayerId = 1, MVPs = 3, Rating = 1.25m },
                new PlayerMatch { MatchId = 2, PlayerId = 1, MVPs = 2, Rating = 1.10m },
                new PlayerMatch { MatchId = 3, PlayerId = 2, MVPs = 4, Rating = 1.32m }
            };
            modelBuilder.Entity<PlayerMatch>().HasData(playerMatches);
    }
}