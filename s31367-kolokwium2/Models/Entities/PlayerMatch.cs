using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace s31367_kolokwium2.Models.Entities;

[Table("Player_Match")]
[PrimaryKey(nameof(MatchId), nameof(PlayerId))]
public class PlayerMatch
{
    public int MatchId { get; set; }
    public Match Match { get; set; } = null!;
    
    public int PlayerId { get; set; }
    public Player Player { get; set; } = null!;
    
    [Required]
    public int MVPs { get; set; }
    
    [Required, Column(TypeName = "decimal(4,2)")]
    public decimal Rating { get; set; }
}