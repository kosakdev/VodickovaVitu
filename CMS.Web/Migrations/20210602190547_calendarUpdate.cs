using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Web.Migrations
{
    public partial class calendarUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BandCompositionId",
                table: "Calendar",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EventTypeId",
                table: "Calendar",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BandCompositionEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandCompositionEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypeEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypeEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendar_BandCompositionId",
                table: "Calendar",
                column: "BandCompositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendar_EventTypeId",
                table: "Calendar",
                column: "EventTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendar_BandCompositionEntity_BandCompositionId",
                table: "Calendar",
                column: "BandCompositionId",
                principalTable: "BandCompositionEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calendar_EventTypeEntity_EventTypeId",
                table: "Calendar",
                column: "EventTypeId",
                principalTable: "EventTypeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendar_BandCompositionEntity_BandCompositionId",
                table: "Calendar");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendar_EventTypeEntity_EventTypeId",
                table: "Calendar");

            migrationBuilder.DropTable(
                name: "BandCompositionEntity");

            migrationBuilder.DropTable(
                name: "EventTypeEntity");

            migrationBuilder.DropIndex(
                name: "IX_Calendar_BandCompositionId",
                table: "Calendar");

            migrationBuilder.DropIndex(
                name: "IX_Calendar_EventTypeId",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "BandCompositionId",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "EventTypeId",
                table: "Calendar");
        }
    }
}
