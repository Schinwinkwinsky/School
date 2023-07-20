using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Data.Migrations
{
    public partial class RenameCourseAndPeriodTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSubject_Course_CoursesId",
                table: "CourseSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Period_Course_CourseId",
                table: "Period");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_Period_PeriodId",
                table: "SchoolClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Period",
                table: "Period");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Period",
                newName: "Periods");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Period_CourseId",
                table: "Periods",
                newName: "IX_Periods_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Periods",
                table: "Periods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSubject_Courses_CoursesId",
                table: "CourseSubject",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Periods_Courses_CourseId",
                table: "Periods",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_Periods_PeriodId",
                table: "SchoolClasses",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSubject_Courses_CoursesId",
                table: "CourseSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Periods_Courses_CourseId",
                table: "Periods");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_Periods_PeriodId",
                table: "SchoolClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Periods",
                table: "Periods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Periods",
                newName: "Period");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Periods_CourseId",
                table: "Period",
                newName: "IX_Period_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Period",
                table: "Period",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSubject_Course_CoursesId",
                table: "CourseSubject",
                column: "CoursesId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Period_Course_CourseId",
                table: "Period",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_Period_PeriodId",
                table: "SchoolClasses",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
