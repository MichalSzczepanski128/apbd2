using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kol2s31448.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_Race_Race_RadeId",
                table: "Track_Race");

            migrationBuilder.RenameColumn(
                name: "RadeId",
                table: "Track_Race",
                newName: "RaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Track_Race_RadeId",
                table: "Track_Race",
                newName: "IX_Track_Race_RaceId");

            migrationBuilder.InsertData(
                table: "Race",
                columns: new[] { "RaceId", "Date", "Location", "Name" },
                values: new object[] { 1, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warszawa", "racename1" });

            migrationBuilder.InsertData(
                table: "Racer",
                columns: new[] { "RacerId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Aski", "Kowalski" },
                    { 2, "Bski", "Awalski" }
                });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "TrackId", "LengthInKm", "Name" },
                values: new object[] { 1, 10m, "track1" });

            migrationBuilder.InsertData(
                table: "Track_Race",
                columns: new[] { "TrackRadeId", "BestTimeInSeconds", "Laps", "RaceId", "TrackId" },
                values: new object[] { 1, 10, 2, 1, 1 });

            migrationBuilder.InsertData(
                table: "Race_Participation",
                columns: new[] { "RacerId", "TrackRaceId", "FinishTimeInSeconds", "Position" },
                values: new object[] { 1, 1, 2, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Race_Race_RaceId",
                table: "Track_Race",
                column: "RaceId",
                principalTable: "Race",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_Race_Race_RaceId",
                table: "Track_Race");

            migrationBuilder.DeleteData(
                table: "Race_Participation",
                keyColumns: new[] { "RacerId", "TrackRaceId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Racer",
                keyColumn: "RacerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Racer",
                keyColumn: "RacerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Track_Race",
                keyColumn: "TrackRadeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "RaceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "RaceId",
                table: "Track_Race",
                newName: "RadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Track_Race_RaceId",
                table: "Track_Race",
                newName: "IX_Track_Race_RadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Race_Race_RadeId",
                table: "Track_Race",
                column: "RadeId",
                principalTable: "Race",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
