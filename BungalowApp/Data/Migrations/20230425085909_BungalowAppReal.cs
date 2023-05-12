using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BungalowApp.Data.Migrations
{
    public partial class BungalowAppReal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReservationList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationList_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bungalow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BungalowId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssigneeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Slots = table.Column<int>(type: "int", nullable: false),
                    Smokers = table.Column<bool>(type: "bit", nullable: false),
                    Pets = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerNight = table.Column<double>(type: "float", nullable: false),
                    ReservationListId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationListId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bungalow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bungalow_AspNetUsers_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bungalow_ReservationList_ReservationListId1",
                        column: x => x.ReservationListId1,
                        principalTable: "ReservationList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bungalow_AssigneeId",
                table: "Bungalow",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bungalow_ReservationListId1",
                table: "Bungalow",
                column: "ReservationListId1");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationList_UserId",
                table: "ReservationList",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bungalow");

            migrationBuilder.DropTable(
                name: "ReservationList");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
