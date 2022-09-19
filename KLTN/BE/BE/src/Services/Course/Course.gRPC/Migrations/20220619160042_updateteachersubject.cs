using Microsoft.EntityFrameworkCore.Migrations;

namespace Course.gRPC.Migrations
{
    public partial class updateteachersubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherSubjects_SubjectId_SemesterId",
                table: "TeacherSubjects");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TeacherSubjects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_SubjectId_SemesterId_Code_TeacherId",
                table: "TeacherSubjects",
                columns: new[] { "SubjectId", "SemesterId", "Code", "TeacherId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherSubjects_SubjectId_SemesterId_Code_TeacherId",
                table: "TeacherSubjects");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TeacherSubjects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_SubjectId_SemesterId",
                table: "TeacherSubjects",
                columns: new[] { "SubjectId", "SemesterId" },
                unique: true,
                filter: "[SubjectId] IS NOT NULL AND [SemesterId] IS NOT NULL");
        }
    }
}
