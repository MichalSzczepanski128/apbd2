using Kol2s31448.Data;
using Kol2s31448.DTOs;
using Kol2s31448.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Kol2s31448.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<RacerParticipationDto> GetRacerParticipationsById(int racerId)
    {
        var RacerParticipation = await _context.Racers
            .Select(e => new RacerParticipationDto
            {
                RacerId = e.RacerId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Participations = e.RaceParticipations.Select(e => new ParticipationDto()
                {
                    Race = new RaceDto()
                    {
                        Name = e.TrackRace.Race.Name,
                        Location = e.TrackRace.Race.Location,
                        Date = e.TrackRace.Race.Date,
                    },
                    Track = new TrackDto(){
                        Name = e.TrackRace.Track.Name,
                        LengthInKm = e.TrackRace.Track.LengthInKm,
                    },
                    Laps = e.TrackRace.Laps,
                    FinishTimeInSeconds = e.FinishTimeInSeconds,
                    Position = e.Position,
                }).ToList()
            })
            .FirstOrDefaultAsync(e => e.RacerId == racerId);

        if (RacerParticipation is null)
            throw new NotFoundException();
        
        return RacerParticipation;
    }
}