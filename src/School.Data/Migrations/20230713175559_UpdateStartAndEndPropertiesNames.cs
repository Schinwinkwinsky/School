using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Data.Migrations
{
    public partial class UpdateStartAndEndPropertiesNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Period",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Period",
                newName: "EndDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Period",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Period",
                newName: "End");
        }
    }
}
