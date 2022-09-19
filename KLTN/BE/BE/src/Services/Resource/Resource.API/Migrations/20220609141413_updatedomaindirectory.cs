using Microsoft.EntityFrameworkCore.Migrations;

namespace Resource.API.Migrations
{
    public partial class updatedomaindirectory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DirectoryId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_DirectoryId",
                table: "Files",
                column: "DirectoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_DomainDirectories_DirectoryId",
                table: "Files",
                column: "DirectoryId",
                principalTable: "DomainDirectories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_DomainDirectories_DirectoryId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_DirectoryId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "DirectoryId",
                table: "Files");
        }
    }
}
