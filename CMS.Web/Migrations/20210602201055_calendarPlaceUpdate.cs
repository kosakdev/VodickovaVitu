using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Web.Migrations
{
    public partial class calendarPlaceUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Calendar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Place",
                table: "Calendar");
        }
    }
}
