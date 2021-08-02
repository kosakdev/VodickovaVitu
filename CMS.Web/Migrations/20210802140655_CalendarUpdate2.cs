using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Web.Migrations
{
    public partial class CalendarUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendar_BandCompositionEntity_BandCompositionId",
                table: "Calendar");

            migrationBuilder.DropTable(
                name: "BandCompositionEntity");

            migrationBuilder.DropIndex(
                name: "IX_Calendar_BandCompositionId",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "BandCompositionId",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Calendar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BandCompositionId",
                table: "Calendar",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Calendar",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BandCompositionEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandCompositionEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendar_BandCompositionId",
                table: "Calendar",
                column: "BandCompositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendar_BandCompositionEntity_BandCompositionId",
                table: "Calendar",
                column: "BandCompositionId",
                principalTable: "BandCompositionEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
