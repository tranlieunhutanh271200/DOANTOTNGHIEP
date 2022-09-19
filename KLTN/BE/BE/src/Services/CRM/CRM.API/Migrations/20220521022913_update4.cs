using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CRM.API.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentAbsents_TicketId",
                table: "StudentAbsents");

            migrationBuilder.DropIndex(
                name: "IX_AccessoryBooks_TicketId",
                table: "AccessoryBooks");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerUsername",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Accessories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Accessories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StudentAbsents_TicketId",
                table: "StudentAbsents",
                column: "TicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryBooks_TicketId",
                table: "AccessoryBooks",
                column: "TicketId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentAbsents_TicketId",
                table: "StudentAbsents");

            migrationBuilder.DropIndex(
                name: "IX_AccessoryBooks_TicketId",
                table: "AccessoryBooks");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Accessories");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Accessories");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerUsername",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAbsents_TicketId",
                table: "StudentAbsents",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryBooks_TicketId",
                table: "AccessoryBooks",
                column: "TicketId");
        }
    }
}
