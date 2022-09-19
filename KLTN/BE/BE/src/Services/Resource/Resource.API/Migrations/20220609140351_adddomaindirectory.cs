using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Resource.API.Migrations
{
    public partial class adddomaindirectory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DomainDirectories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentDirectoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainDirectories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DomainDirectories_DomainDirectories_ParentDirectoryId",
                        column: x => x.ParentDirectoryId,
                        principalTable: "DomainDirectories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DomainDirectories_ParentDirectoryId",
                table: "DomainDirectories",
                column: "ParentDirectoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DomainDirectories");
        }
    }
}
