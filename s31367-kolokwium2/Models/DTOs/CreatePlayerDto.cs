using System.ComponentModel.DataAnnotations;

namespace s31367_kolokwium2.Models.DTOs;

public class CreatePlayerDto
{
    [Required]
    public string FirstName { get; set; } = null!;
    
    [Required]
    public string LastName { get; set; } = null!;
    
    [Required]
    public DateTime BirthDate { get; set; }
    
    [Required]
    public List<MatchParticipationDto> Matches { get; set; } = new();
}