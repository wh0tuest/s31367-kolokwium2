using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace s31367_kolokwium2.Models.Entities;

[Table("Player")]
public class Player
{
    [Key]
    public int PlayerId { get; set; }
    
    [Required, MaxLength(50)]
    public string FirstName { get; set; } = null!;
    
    [Required, MaxLength(100)]
    public string LastName { get; set; } = null!;
    
    [Required]
    public DateTime BirthDate { get; set; }
    
    public ICollection<PlayerMatch> PlayerMatches { get; set; } = new List<PlayerMatch>();
}