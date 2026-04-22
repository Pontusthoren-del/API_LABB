using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_LABB.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => new { x.PersonId, x.InterestId });
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Alpint och längdskidor", "Skidåkning" },
                    { 2, "Webb- och apputveckling", "Programmering" },
                    { 3, "Laga mat från olika kulturer", "Matlagning" },
                    { 4, "Landskap och porträttfoto", "Fotografi" },
                    { 5, "Motionslöpning och tävling", "Löpning" },
                    { 6, "Spela och lyssna på musik", "Musik" },
                    { 7, "Skönlitteratur och facklitteratur", "Läsning" },
                    { 8, "PC- och konsolspel", "Gaming" },
                    { 9, "Rörlighet och mindfulness", "Yoga" },
                    { 10, "Landsvägscykling och MTB", "Cykling" },
                    { 11, "Inomhus- och utomhusklättring", "Klättring" },
                    { 12, "Se och diskutera film", "Filmklubb" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Anna Svensson", "070-123 45 67" },
                    { 2, "Erik Lindqvist", "073-987 65 43" },
                    { 3, "Maria Johansson", "076-555 12 34" },
                    { 4, "Oskar Bergström", "072-444 98 76" },
                    { 5, "Lina Karlsson", "070-333 21 09" },
                    { 6, "David Nilsson", "073-222 87 65" },
                    { 7, "Sara Eriksson", "076-111 54 32" },
                    { 8, "Johan Petersson", "072-999 43 21" },
                    { 9, "Emma Lundgren", "070-888 76 54" },
                    { 10, "Felix Magnusson", "073-777 65 43" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "InterestId", "Label", "PersonId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "SkiStar", 1, "https://skistar.com" },
                    { 2, 2, "Annas GitHub", 1, "https://github.com/anna" },
                    { 3, 5, "Runners World", 1, "https://runnersworld.com" },
                    { 4, 2, "Stack Overflow", 2, "https://stackoverflow.com" },
                    { 5, 3, "Allt om Mat", 2, "https://alltommat.se" },
                    { 6, 8, "Steam", 2, "https://store.steampowered.com" },
                    { 7, 4, "500px", 3, "https://500px.com" },
                    { 8, 7, "Goodreads", 3, "https://goodreads.com" },
                    { 9, 9, "Yoga Journal", 3, "https://yogajournal.com" },
                    { 10, 5, "Strava", 4, "https://strava.com" },
                    { 11, 10, "Cycling Weekly", 4, "https://cyclingweekly.com" },
                    { 12, 11, "The BMC", 4, "https://thebmc.co.uk" },
                    { 13, 6, "Spotify", 5, "https://spotify.com" },
                    { 14, 7, "Bokus", 5, "https://bokus.com" },
                    { 15, 12, "Filmtipset", 5, "https://filmtipset.se" },
                    { 16, 2, "LeetCode", 6, "https://leetcode.com" },
                    { 17, 8, "Twitch", 6, "https://twitch.tv" },
                    { 18, 11, "Climbing Wall", 6, "https://climbingwall.com" },
                    { 19, 3, "Köket.se", 7, "https://koket.se" },
                    { 20, 9, "Down Dog", 7, "https://downdogapp.com" },
                    { 21, 12, "IMDb", 7, "https://imdb.com" },
                    { 22, 1, "Skidresor.se", 8, "https://skidresor.se" },
                    { 23, 4, "Unsplash", 8, "https://unsplash.com" },
                    { 24, 10, "BikeRadar", 8, "https://bikeradar.com" },
                    { 25, 5, "Garmin Connect", 9, "https://garmin.com" },
                    { 26, 6, "SoundCloud", 9, "https://soundcloud.com" },
                    { 27, 7, "Adlibris", 9, "https://adlibris.com" },
                    { 28, 2, "Microsoft Docs", 10, "https://docs.microsoft.com" },
                    { 29, 8, "IGN", 10, "https://ign.com" },
                    { 30, 12, "Letterboxd", 10, "https://letterboxd.com" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 5, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 8, 2 },
                    { 4, 3 },
                    { 7, 3 },
                    { 9, 3 },
                    { 5, 4 },
                    { 10, 4 },
                    { 11, 4 },
                    { 6, 5 },
                    { 7, 5 },
                    { 12, 5 },
                    { 2, 6 },
                    { 8, 6 },
                    { 11, 6 },
                    { 3, 7 },
                    { 9, 7 },
                    { 12, 7 },
                    { 1, 8 },
                    { 4, 8 },
                    { 10, 8 },
                    { 5, 9 },
                    { 6, 9 },
                    { 7, 9 },
                    { 2, 10 },
                    { 8, 10 },
                    { 12, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_InterestId",
                table: "Links",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonId",
                table: "Links",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestId",
                table: "PersonInterests",
                column: "InterestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
