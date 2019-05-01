using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NameSearchCore.Migrations
{
    public partial class initialDBSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    PicturePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interests_people_PersonId",
                        column: x => x.PersonId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "Address", "Age", "FirstName", "LastName", "PicturePath" },
                values: new object[,]
                {
                    { 1, "1234 Quiet Street", 30, "Henry", "Smith", null },
                    { 2, "1234 Noisy Street", 30, "Lisa", "Rich", null },
                    { 3, "1234 Normal Street", 30, "Emma", "Moses", null },
                    { 4, "1234 Main Street", 30, "Henry", "Moor", null },
                    { 5, "1234 State Street", 30, "Rich", "Lisa", null },
                    { 6, "1234 Wall Street", 30, "John", "Moor", null }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "PersonId", "Value" },
                values: new object[,]
                {
                    { 1, 1, "reading" },
                    { 12, 1, "do nothing" },
                    { 2, 2, "watching movies" },
                    { 11, 2, "running" },
                    { 3, 3, "travelling" },
                    { 10, 3, "biking" },
                    { 4, 4, "biking" },
                    { 9, 4, "travelling" },
                    { 5, 5, "running" },
                    { 8, 5, "watching movies" },
                    { 6, 6, "do nothing" },
                    { 7, 6, "reading" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PersonId",
                table: "Interests",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "people");
        }
    }
}
