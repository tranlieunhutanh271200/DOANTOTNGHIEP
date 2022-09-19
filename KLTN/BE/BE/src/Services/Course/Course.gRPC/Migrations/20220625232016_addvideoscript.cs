using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Course.gRPC.Migrations
{
    public partial class addvideoscript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VideoId",
                table: "SectionScripts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoPath",
                table: "SectionScripts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "SectionScripts");

            migrationBuilder.DropColumn(
                name: "VideoPath",
                table: "SectionScripts");
        }
    }
}
