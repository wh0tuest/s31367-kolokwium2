using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace s31367_kolokwium2.Models.Entities;

public class Match
{
    [Key]
    public int MatchId { get; set; }
    
    [Required]
    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; } = null!;
    
    [Required]
    public int MapId { get; set; }
    public Map Map { get; set; } = null!;
    
    [Required]
    public DateTime MatchDate { get; set; }
    
    [Required]
    public int Team1Score { get; set; }
    
    [Required]
    public int Team2Score { get; set; }
    
    [Column(TypeName = "decimal(4,2)")]
    public decimal BestRating { get; set; }
    
    public ICollection<PlayerMatch> PlayerMatches { get; set; } = new List<PlayerMatch>();
}