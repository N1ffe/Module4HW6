using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Module4HW6.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "date", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Song_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistSong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistSong_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSong_Song_SongId",
                        column: x => x.SongId,
                        principalTable: "Song",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "DateOfBirth", "Email", "InstagramUrl", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "test_artist_name1", null },
                    { 2, new DateTime(1986, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "test_artist_name2", null },
                    { 3, new DateTime(2002, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "test_artist_name3", null },
                    { 4, new DateTime(1981, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "test_artist_name4", null },
                    { 5, new DateTime(1999, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "test_artist_name5", null }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "test_genre1" },
                    { 2, "test_genre2" },
                    { 3, "test_genre3" },
                    { 4, "test_genre4" },
                    { 5, "test_genre5" }
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "Id", "Duration", "GenreId", "ReleasedDate", "Title" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 3, 24, 0), 3, new DateTime(2021, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "test_song_name1" },
                    { 2, new TimeSpan(0, 0, 2, 51, 0), 2, new DateTime(2022, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "test_song_name2" },
                    { 3, new TimeSpan(0, 0, 2, 36, 0), 5, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "test_song_name3" },
                    { 4, new TimeSpan(0, 0, 3, 44, 0), 4, new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "test_song_name4" },
                    { 5, new TimeSpan(0, 0, 3, 11, 0), 1, new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "test_song_name5" }
                });

            migrationBuilder.InsertData(
                table: "ArtistSong",
                columns: new[] { "Id", "ArtistId", "SongId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 3 },
                    { 5, 5, 3 },
                    { 6, 3, 4 },
                    { 7, 1, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSong_ArtistId",
                table: "ArtistSong",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSong_SongId",
                table: "ArtistSong",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_GenreId",
                table: "Song",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistSong");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
