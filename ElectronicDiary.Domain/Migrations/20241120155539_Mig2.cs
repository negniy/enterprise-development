using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicDiary.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_Student_id",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Subjects_Subject_id",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_Class_id",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Class_id",
                table: "Students",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_Class_id",
                table: "Students",
                newName: "IX_Students_ClassId");

            migrationBuilder.RenameColumn(
                name: "Subject_id",
                table: "Grades",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "Student_id",
                table: "Grades",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_Subject_id",
                table: "Grades",
                newName: "IX_Grades_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_Student_id",
                table: "Grades",
                newName: "IX_Grades_StudentId");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Students",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                table: "Students",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Passport",
                table: "Students",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Subjects_SubjectId",
                table: "Grades",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Subjects_SubjectId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Students",
                newName: "Class_id");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                newName: "IX_Students_Class_id");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Grades",
                newName: "Subject_id");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Grades",
                newName: "Student_id");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades",
                newName: "IX_Grades_Subject_id");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                newName: "IX_Grades_Student_id");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Students",
                type: "varchar(45)",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                table: "Students",
                type: "varchar(45)",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Passport",
                table: "Students",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                type: "varchar(45)",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_Student_id",
                table: "Grades",
                column: "Student_id",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Subjects_Subject_id",
                table: "Grades",
                column: "Subject_id",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_Class_id",
                table: "Students",
                column: "Class_id",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
