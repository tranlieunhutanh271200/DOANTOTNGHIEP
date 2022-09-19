using Microsoft.EntityFrameworkCore.Migrations;

namespace Course.gRPC.Migrations
{
    public partial class addstudentcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CategoryId",
                table: "Students",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentCategories_CategoryId",
                table: "Students",
                column: "CategoryId",
                principalTable: "StudentCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentCategories_CategoryId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "StudentCategories");

            migrationBuilder.DropIndex(
                name: "IX_Students_CategoryId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Students");
        }
    }
}
