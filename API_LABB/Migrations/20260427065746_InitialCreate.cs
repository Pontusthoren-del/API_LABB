using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_LABB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Persons_PersonId",
                table: "Links");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Links",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Links_PersonId",
                table: "Links",
                newName: "IX_Links_UserId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => new { x.UserId, x.InterestId });
                    table.ForeignKey(
                        name: "FK_UserInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInterests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
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
                table: "UserInterests",
                columns: new[] { "InterestId", "UserId" },
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
                name: "IX_UserInterests_InterestId",
                table: "UserInterests",
                column: "InterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Users_UserId",
                table: "Links",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Users_UserId",
                table: "Links");

            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Links",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Links_UserId",
                table: "Links",
                newName: "IX_Links_PersonId");

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
                name: "IX_PersonInterests_InterestId",
                table: "PersonInterests",
                column: "InterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Persons_PersonId",
                table: "Links",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
