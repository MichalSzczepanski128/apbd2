using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kol2s31448.Models;

[Table("Race")]
public class Race
{
    [Key]
    public int RaceId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    [MaxLength(100)]
    public string Location { get; set; } = null!;
    public DateTime Date { get; set; }
    
    public ICollection<TrackRace> Tracks { get; set; } = null!;
}