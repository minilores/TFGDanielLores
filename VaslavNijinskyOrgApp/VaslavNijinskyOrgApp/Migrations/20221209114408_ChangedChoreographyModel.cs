using Microsoft.EntityFrameworkCore.Migrations;

namespace VaslavNijinskyOrgApp.Migrations
{
    public partial class ChangedChoreographyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GroupCoach",
                table: "Choreography",
                newName: "Manager");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manager",
                table: "Choreography",
                newName: "GroupCoach");
        }
    }
}
