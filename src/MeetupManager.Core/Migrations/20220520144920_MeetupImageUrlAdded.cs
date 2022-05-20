using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetupManager.Core.Migrations
{
    public partial class MeetupImageUrlAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Meetups",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Meetups");
        }
    }
}
