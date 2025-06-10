using System.ComponentModel.DataAnnotations;

namespace s31367_kolokwium2.Models.DTOs;

public class MatchParticipationDto
{
    [Required]
    public int MatchId { get; set; }

    [Required]
    public int MVPs { get; set; }

    [Required]
    public decimal Rating { get; set; }
}