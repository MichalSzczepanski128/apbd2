using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kol2s31448.Models;

[Table("Track_Race")]
public class TrackRace
{
    [Key]
    public int TrackRadeId { get; set; }
    [ForeignKey(nameof(Track))]
    public int TrackId { get; set; }
    [ForeignKey(nameof(Race))]
    public int RaceId { get; set; }
    public int Laps { get; set; }
    public int? BestTimeInSeconds { get; set; }

    public ICollection<RaceParticipation> RaceParticipations { get; set; } = null!;
    
    public Track Track { get; set; } = null!;
    public Race Race { get; set; } = null!;

}