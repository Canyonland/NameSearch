using Microsoft.EntityFrameworkCore.Migrations;

namespace NameSearchCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                name: "PeopleInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(nullable: false),
                    InterestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeopleInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleInterests_people_PersonId",
                        column: x => x.PersonId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Value" },
                values: new object[] { 1, "reading" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Value" },
                values: new object[] { 9, "fishing" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Value" },
                values: new object[] { 8, "boating" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Value" },
                values: new object[] { 7, "shopping" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Value" },
                values: new object[] { 6, "gardening" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Value" },
                values: new object[] { 10, "swimming" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Value" },
                values: new object[] { 4, "biking" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Value" },
                values: new object[] { 3, "travelling" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Value" },
                values: new object[] { 2, "watching movies" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Value" },
                values: new object[] { 5, "running" });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "Address", "Age", "FirstName", "LastName", "PicturePath" },
                values: new object[] { 9, "1234 Fall Street", 30, "Tiffany", "Locante", null });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "Address", "Age", "FirstName", "LastName", "PicturePath" },
                values: new object[] { 1, "1234 Quiet Street", 30, "Henry", "Smith", null });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "Address", "Age", "FirstName", "LastName", "PicturePath" },
                values: new object[] { 2, "1234 Noisy Street", 30, "Lisa", "Rich", null });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "Address", "Age", "FirstName", "LastName", "PicturePath" },
                values: new object[] { 3, "1234 Normal Street", 30, "Emma", "Moses", null });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "Address", "Age", "FirstName", "LastName", "PicturePath" },
                values: new object[] { 4, "1234 Main Street", 30, "Henry", "Moor", null });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "Address", "Age", "FirstName", "LastName", "PicturePath" },
                values: new object[] { 5, "1234 State Street", 30, "Rich", "Lisa", null });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "Address", "Age", "FirstName", "LastName", "PicturePath" },
                values: new object[] { 6, "1234 Wall Street", 30, "John", "Moor", null });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "Address", "Age", "FirstName", "LastName", "PicturePath" },
                values: new object[] { 7, "1234 Spring Street", 30, "Mark", "Dean", null });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "Address", "Age", "FirstName", "LastName", "PicturePath" },
                values: new object[] { 8, "1234 Summer Street", 30, "Rob", "Henderson", null });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "Address", "Age", "FirstName", "LastName", "PicturePath" },
                values: new object[] { 10, "1234 Winter Street", 30, "Laura", "Carrell", null });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 18, 10, 9 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 17, 9, 9 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 16, 9, 8 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 15, 8, 8 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 14, 8, 7 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 13, 7, 7 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 12, 7, 6 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 11, 6, 6 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 10, 6, 5 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 9, 5, 5 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 8, 5, 4 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 7, 4, 4 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 6, 4, 3 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 5, 3, 3 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 4, 3, 2 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 3, 2, 2 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 19, 10, 10 });

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[] { 20, 1, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleInterests_InterestId",
                table: "PeopleInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleInterests_PersonId",
                table: "PeopleInterests",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeopleInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "people");
        }
    }
}
