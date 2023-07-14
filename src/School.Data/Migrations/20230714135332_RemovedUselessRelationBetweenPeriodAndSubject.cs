using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Data.Migrations
{
    public partial class RemovedUselessRelationBetweenPeriodAndSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Period_Subjects_SubjectId",
                table: "Period");

            migrationBuilder.DropIndex(
                name: "IX_Period_SubjectId",
                table: "Period");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Period");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "Period",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Period_SubjectId",
                table: "Period",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Period_Subjects_SubjectId",
                table: "Period",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }
    }
}
