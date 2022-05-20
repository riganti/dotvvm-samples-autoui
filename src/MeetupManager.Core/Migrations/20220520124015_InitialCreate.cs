using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetupManager.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Zip = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meetups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BeginDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetups_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Austria" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Belgium" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Bulgaria" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Croatia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Cyprus" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Czech Republic" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Denmark" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Estonia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Finland" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "France" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "Germany" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "Greece" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 13, "Hungary" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 14, "Ireland" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 15, "Italy" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 16, "Latvia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 17, "Lithuania" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 18, "Luxembourg" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 19, "Malta" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 20, "Netherlands" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 21, "Poland" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 22, "Portugal" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 23, "Romania" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 24, "Slovakia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 25, "Slovenia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 26, "Spain" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 27, "Sweden" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City", "CountryId", "Name", "Zip" },
                values: new object[] { 1, "Sokolovska 352/215", "Praha", 6, "RIGANTI Prague", "190 00" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City", "CountryId", "Name", "Zip" },
                values: new object[] { 2, "Hybesova 61", "Brno", 6, "RIGANTI Brno", "602 00" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City", "CountryId", "Name", "Zip" },
                values: new object[] { 3, null, "Bratislava", 24, "Bratislava Startup Hub", null });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City", "CountryId", "Name", "Zip" },
                values: new object[] { 4, null, "Berlin", 11, "Berlin Cowork", null });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City", "CountryId", "Name", "Zip" },
                values: new object[] { 5, null, "Dresden", 11, "Community Hub Dresden", null });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CountryId",
                table: "Locations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetups_LocationId",
                table: "Meetups",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meetups");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
