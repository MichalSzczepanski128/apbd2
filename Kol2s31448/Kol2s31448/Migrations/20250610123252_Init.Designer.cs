﻿// <auto-generated />
using System;
using Kol2s31448.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kol2s31448.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20250610123252_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kol2s31448.Models.Race", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RaceId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RaceId");

                    b.ToTable("Race");
                });

            modelBuilder.Entity("Kol2s31448.Models.RaceParticipation", b =>
                {
                    b.Property<int>("TrackRaceId")
                        .HasColumnType("int");

                    b.Property<int>("RacerId")
                        .HasColumnType("int");

                    b.Property<int>("FinishTimeInSeconds")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("TrackRaceId", "RacerId");

                    b.HasIndex("RacerId");

                    b.ToTable("Race_Participation");
                });

            modelBuilder.Entity("Kol2s31448.Models.Racer", b =>
                {
                    b.Property<int>("RacerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RacerId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RacerId");

                    b.ToTable("Racer");
                });

            modelBuilder.Entity("Kol2s31448.Models.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrackId"));

                    b.Property<decimal>("LengthInKm")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TrackId");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("Kol2s31448.Models.TrackRace", b =>
                {
                    b.Property<int>("TrackRadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrackRadeId"));

                    b.Property<int?>("BestTimeInSeconds")
                        .HasColumnType("int");

                    b.Property<int>("Laps")
                        .HasColumnType("int");

                    b.Property<int>("RadeId")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("TrackRadeId");

                    b.HasIndex("RadeId");

                    b.HasIndex("TrackId");

                    b.ToTable("Track_Race");
                });

            modelBuilder.Entity("Kol2s31448.Models.RaceParticipation", b =>
                {
                    b.HasOne("Kol2s31448.Models.Racer", "Racer")
                        .WithMany("RaceParticipations")
                        .HasForeignKey("RacerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kol2s31448.Models.TrackRace", "TrackRace")
                        .WithMany("RaceParticipations")
                        .HasForeignKey("TrackRaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Racer");

                    b.Navigation("TrackRace");
                });

            modelBuilder.Entity("Kol2s31448.Models.TrackRace", b =>
                {
                    b.HasOne("Kol2s31448.Models.Race", "Race")
                        .WithMany("Tracks")
                        .HasForeignKey("RadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kol2s31448.Models.Track", "Track")
                        .WithMany("TrackRaces")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Kol2s31448.Models.Race", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Kol2s31448.Models.Racer", b =>
                {
                    b.Navigation("RaceParticipations");
                });

            modelBuilder.Entity("Kol2s31448.Models.Track", b =>
                {
                    b.Navigation("TrackRaces");
                });

            modelBuilder.Entity("Kol2s31448.Models.TrackRace", b =>
                {
                    b.Navigation("RaceParticipations");
                });
#pragma warning restore 612, 618
        }
    }
}
