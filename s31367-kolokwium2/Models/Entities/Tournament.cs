using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace s31367_kolokwium2.Models.Entities;

[Table("Tournament")]
public class Tournament
{
    [Key]
    public int TournamentId { get; set; }
    
    [Required, MaxLength(50)]
    public string Name { get; set; } = null!;
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
    
    public ICollection<Match> Matches { get; set; } = new List<Match>();
}