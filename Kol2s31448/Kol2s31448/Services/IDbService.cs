using Kol2s31448.DTOs;
using Kol2s31448.Models;

namespace Kol2s31448.Services;

public interface IDbService
{
    Task<RacerParticipationDto> GetRacerParticipationsById(int racerId);
}