using Microsoft.EntityFrameworkCore;
using s31367_kolokwium2.Data;
using s31367_kolokwium2.Models.DTOs;
using s31367_kolokwium2.Models.Entities;

namespace s31367_kolokwium2.Services;

public interface IPlayersService
{
    Task<object?> GetPlayerWithMatchesAsync(int playerId);
    Task<(bool IsSuccess, int? PlayerId, string? ErrorMessage)> AddPlayerWithMatchesAsync(CreatePlayerDto dto);
}

public class PlayersService : IPlayersService
{
    private readonly AppDbContext _context;
    
    public PlayersService(AppDbContext dbContext)
    {
        _context = dbContext;
    }
    
    public async Task<object?> GetPlayerWithMatchesAsync(int playerId)
    {
        var player = await _context.Players
            .Include(p => p.PlayerMatches)
                .ThenInclude(pm => pm.Match)
                    .ThenInclude(m => m.Tournament)
            .Include(p => p.PlayerMatches)
                .ThenInclude(pm => pm.Match)
                    .ThenInclude(m => m.Map)
            .FirstOrDefaultAsync(p => p.PlayerId == playerId);

        if (player == null) return null;

        return new
        {
            player.PlayerId,
            player.FirstName,
            player.LastName,
            player.BirthDate,
            Matches = player.PlayerMatches.Select(pm => new
            {
                tournament = pm.Match.Tournament.Name,
                map = pm.Match.Map.Name,
                date = pm.Match.MatchDate,
                MVPs = pm.MVPs,
                rating = pm.Rating,
                team1Score = pm.Match.Team1Score,
                team2Score = pm.Match.Team2Score
            })
        };
    }

    public async Task<(bool IsSuccess, int? PlayerId, string? ErrorMessage)> AddPlayerWithMatchesAsync(CreatePlayerDto dto)
    {
        var player = new Player
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            BirthDate = dto.BirthDate,
            PlayerMatches = new List<PlayerMatch>()
        };

        foreach (var matchDto in dto.Matches)
        {
            var match = await _context.Matches.FindAsync(matchDto.MatchId);
            if (match == null)
                return (false, null, $"Match ID {matchDto.MatchId} not found");

            if (matchDto.Rating > match.BestRating)
                match.BestRating = matchDto.Rating;

            player.PlayerMatches.Add(new PlayerMatch
            {
                MatchId = matchDto.MatchId,
                MVPs = matchDto.MVPs,
                Rating = matchDto.Rating
            });
        }

        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return (true, player.PlayerId, null);
    }
}