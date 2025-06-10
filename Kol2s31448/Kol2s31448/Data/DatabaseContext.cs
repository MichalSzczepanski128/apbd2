using Kol2s31448.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2s31448.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Racer> Racers { get; set; }
    public DbSet<RaceParticipation> RaceParticipations { get; set; }
    public DbSet<TrackRace> TrackRaces { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Race> Races { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
         modelBuilder.Entity<Racer>().HasData(new List<Racer>()
         {
             new Racer() { RacerId = 1, FirstName = "Aski", LastName = "Kowalski" },
             new Racer() { RacerId = 2, FirstName = "Bski", LastName = "Awalski" },
         });
         modelBuilder.Entity<RaceParticipation>().HasData(new List<RaceParticipation>()
         {
             new RaceParticipation() { TrackRaceId = 1, RacerId = 1,FinishTimeInSeconds = 2, Position = 1}
         });
         modelBuilder.Entity<TrackRace>().HasData(new List<TrackRace>()
         {
             new TrackRace() {TrackRadeId = 1,TrackId = 1, RaceId = 1, Laps = 2, BestTimeInSeconds = 10}
         });
         modelBuilder.Entity<Race>().HasData(new List<Race>()
         {
             new Race() {RaceId = 1, Name = "racename1", Location = "Warszawa", Date = DateTime.Parse("2025-05-01")},
         });
         modelBuilder.Entity<Track>().HasData(new List<Track>()
         {
             new Track() { TrackId = 1, Name = "track1", LengthInKm = 10}
         });
     }
}