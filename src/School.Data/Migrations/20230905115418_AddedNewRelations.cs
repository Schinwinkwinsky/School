using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Data.Migrations
{
    public partial class AddedNewRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KnowledgeAreaSubject_KnowledgeAreas_KnowledgeAreasId",
                table: "KnowledgeAreaSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_KnowledgeAreaSubject_Subjects_SubjectsId",
                table: "KnowledgeAreaSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_KnowledgeAreaTeacher_KnowledgeAreas_KnowledgeAreasId",
                table: "KnowledgeAreaTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_KnowledgeAreaTeacher_Teachers_TeachersId",
                table: "KnowledgeAreaTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClassStudent_SchoolClasses_SchoolClassesId",
                table: "SchoolClassStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClassStudent_Students_StudentsId",
                table: "SchoolClassStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolClassStudent",
                table: "SchoolClassStudent");

            migrationBuilder.DropIndex(
                name: "IX_SchoolClassStudent_StudentsId",
                table: "SchoolClassStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnowledgeAreaTeacher",
                table: "KnowledgeAreaTeacher");

            migrationBuilder.DropIndex(
                name: "IX_KnowledgeAreaTeacher_TeachersId",
                table: "KnowledgeAreaTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnowledgeAreaSubject",
                table: "KnowledgeAreaSubject");

            migrationBuilder.DropIndex(
                name: "IX_KnowledgeAreaSubject_SubjectsId",
                table: "KnowledgeAreaSubject");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "SchoolClassStudent",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "SchoolClassesId",
                table: "SchoolClassStudent",
                newName: "SchoolClassId");

            migrationBuilder.RenameColumn(
                name: "TeachersId",
                table: "KnowledgeAreaTeacher",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "KnowledgeAreasId",
                table: "KnowledgeAreaTeacher",
                newName: "KnowledgeAreaId");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "KnowledgeAreaSubject",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "KnowledgeAreasId",
                table: "KnowledgeAreaSubject",
                newName: "KnowledgeAreaId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SchoolClassStudent",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "SchoolClassStudent",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "SchoolClassStudent",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "SchoolClassStudent",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "SchoolClassStudent",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "SchoolClassStudent",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "KnowledgeAreaTeacher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "KnowledgeAreaTeacher",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "KnowledgeAreaTeacher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "KnowledgeAreaTeacher",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "KnowledgeAreaTeacher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "KnowledgeAreaTeacher",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "KnowledgeAreaSubject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "KnowledgeAreaSubject",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "KnowledgeAreaSubject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "KnowledgeAreaSubject",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "KnowledgeAreaSubject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "KnowledgeAreaSubject",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolClassStudent",
                table: "SchoolClassStudent",
                columns: new[] { "SchoolClassId", "StudentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnowledgeAreaTeacher",
                table: "KnowledgeAreaTeacher",
                columns: new[] { "KnowledgeAreaId", "TeacherId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnowledgeAreaSubject",
                table: "KnowledgeAreaSubject",
                columns: new[] { "KnowledgeAreaId", "SubjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassStudent_StudentId",
                table: "SchoolClassStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeAreaTeacher_TeacherId",
                table: "KnowledgeAreaTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeAreaSubject_SubjectId",
                table: "KnowledgeAreaSubject",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_KnowledgeAreaSubject_KnowledgeAreas_KnowledgeAreaId",
                table: "KnowledgeAreaSubject",
                column: "KnowledgeAreaId",
                principalTable: "KnowledgeAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnowledgeAreaSubject_Subjects_SubjectId",
                table: "KnowledgeAreaSubject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnowledgeAreaTeacher_KnowledgeAreas_KnowledgeAreaId",
                table: "KnowledgeAreaTeacher",
                column: "KnowledgeAreaId",
                principalTable: "KnowledgeAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnowledgeAreaTeacher_Teachers_TeacherId",
                table: "KnowledgeAreaTeacher",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClassStudent_SchoolClasses_SchoolClassId",
                table: "SchoolClassStudent",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClassStudent_Students_StudentId",
                table: "SchoolClassStudent",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KnowledgeAreaSubject_KnowledgeAreas_KnowledgeAreaId",
                table: "KnowledgeAreaSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_KnowledgeAreaSubject_Subjects_SubjectId",
                table: "KnowledgeAreaSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_KnowledgeAreaTeacher_KnowledgeAreas_KnowledgeAreaId",
                table: "KnowledgeAreaTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_KnowledgeAreaTeacher_Teachers_TeacherId",
                table: "KnowledgeAreaTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClassStudent_SchoolClasses_SchoolClassId",
                table: "SchoolClassStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClassStudent_Students_StudentId",
                table: "SchoolClassStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolClassStudent",
                table: "SchoolClassStudent");

            migrationBuilder.DropIndex(
                name: "IX_SchoolClassStudent_StudentId",
                table: "SchoolClassStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnowledgeAreaTeacher",
                table: "KnowledgeAreaTeacher");

            migrationBuilder.DropIndex(
                name: "IX_KnowledgeAreaTeacher_TeacherId",
                table: "KnowledgeAreaTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnowledgeAreaSubject",
                table: "KnowledgeAreaSubject");

            migrationBuilder.DropIndex(
                name: "IX_KnowledgeAreaSubject_SubjectId",
                table: "KnowledgeAreaSubject");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SchoolClassStudent");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SchoolClassStudent");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "SchoolClassStudent");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SchoolClassStudent");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "SchoolClassStudent");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "SchoolClassStudent");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "KnowledgeAreaTeacher");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "KnowledgeAreaTeacher");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "KnowledgeAreaTeacher");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "KnowledgeAreaTeacher");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "KnowledgeAreaTeacher");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "KnowledgeAreaTeacher");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "KnowledgeAreaSubject");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "KnowledgeAreaSubject");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "KnowledgeAreaSubject");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "KnowledgeAreaSubject");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "KnowledgeAreaSubject");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "KnowledgeAreaSubject");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "SchoolClassStudent",
                newName: "StudentsId");

            migrationBuilder.RenameColumn(
                name: "SchoolClassId",
                table: "SchoolClassStudent",
                newName: "SchoolClassesId");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "KnowledgeAreaTeacher",
                newName: "TeachersId");

            migrationBuilder.RenameColumn(
                name: "KnowledgeAreaId",
                table: "KnowledgeAreaTeacher",
                newName: "KnowledgeAreasId");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "KnowledgeAreaSubject",
                newName: "SubjectsId");

            migrationBuilder.RenameColumn(
                name: "KnowledgeAreaId",
                table: "KnowledgeAreaSubject",
                newName: "KnowledgeAreasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolClassStudent",
                table: "SchoolClassStudent",
                columns: new[] { "SchoolClassesId", "StudentsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnowledgeAreaTeacher",
                table: "KnowledgeAreaTeacher",
                columns: new[] { "KnowledgeAreasId", "TeachersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnowledgeAreaSubject",
                table: "KnowledgeAreaSubject",
                columns: new[] { "KnowledgeAreasId", "SubjectsId" });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassStudent_StudentsId",
                table: "SchoolClassStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeAreaTeacher_TeachersId",
                table: "KnowledgeAreaTeacher",
                column: "TeachersId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeAreaSubject_SubjectsId",
                table: "KnowledgeAreaSubject",
                column: "SubjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_KnowledgeAreaSubject_KnowledgeAreas_KnowledgeAreasId",
                table: "KnowledgeAreaSubject",
                column: "KnowledgeAreasId",
                principalTable: "KnowledgeAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnowledgeAreaSubject_Subjects_SubjectsId",
                table: "KnowledgeAreaSubject",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnowledgeAreaTeacher_KnowledgeAreas_KnowledgeAreasId",
                table: "KnowledgeAreaTeacher",
                column: "KnowledgeAreasId",
                principalTable: "KnowledgeAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnowledgeAreaTeacher_Teachers_TeachersId",
                table: "KnowledgeAreaTeacher",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClassStudent_SchoolClasses_SchoolClassesId",
                table: "SchoolClassStudent",
                column: "SchoolClassesId",
                principalTable: "SchoolClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClassStudent_Students_StudentsId",
                table: "SchoolClassStudent",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
