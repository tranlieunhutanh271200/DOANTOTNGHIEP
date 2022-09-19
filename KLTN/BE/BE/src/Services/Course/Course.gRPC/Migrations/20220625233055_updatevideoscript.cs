using Microsoft.EntityFrameworkCore.Migrations;

namespace Course.gRPC.Migrations
{
    public partial class updatevideoscript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoScript_Description",
                table: "SectionScripts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoScript_Title",
                table: "SectionScripts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoScript_Description",
                table: "SectionScripts");

            migrationBuilder.DropColumn(
                name: "VideoScript_Title",
                table: "SectionScripts");
        }
    }
}
