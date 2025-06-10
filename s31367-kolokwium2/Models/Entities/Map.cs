using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace s31367_kolokwium2.Models.Entities;

[Table("Map")]
public class Map
{
    [Key]
    public int MapId { get; set; }
    
    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;
    
    [Required, MaxLength(100)]
    public string Type { get; set; } = null!;
    
    public ICollection<Match> Matches { get; set; } = new List<Match>();
}