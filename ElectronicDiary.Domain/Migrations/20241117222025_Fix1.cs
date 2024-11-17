using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicDiary.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_student_id",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Subjects_subject_id",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_class_id",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "class_id",
                table: "Students",
                newName: "Class_id");

            migrationBuilder.RenameIndex(
                name: "IX_Students_class_id",
                table: "Students",
                newName: "IX_Students_Class_id");

            migrationBuilder.RenameColumn(
                name: "subject_id",
                table: "Grades",
                newName: "Subject_id");

            migrationBuilder.RenameColumn(
                name: "student_id",
                table: "Grades",
                newName: "Student_id");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_subject_id",
                table: "Grades",
                newName: "IX_Grades_Subject_id");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_student_id",
                table: "Grades",
                newName: "IX_Grades_Student_id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "class_id");

            migrationBuilder.RenameIndex(
                name: "IX_Students_Class_id",
                table: "Students",
                newName: "IX_Students_class_id");

            migrationBuilder.RenameColumn(
                name: "Subject_id",
                table: "Grades",
                newName: "subject_id");

            migrationBuilder.RenameColumn(
                name: "Student_id",
                table: "Grades",
                newName: "student_id");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_Subject_id",
                table: "Grades",
                newName: "IX_Grades_subject_id");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_Student_id",
                table: "Grades",
                newName: "IX_Grades_student_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_student_id",
                table: "Grades",
                column: "student_id",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Subjects_subject_id",
                table: "Grades",
                column: "subject_id",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_class_id",
                table: "Students",
                column: "class_id",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
