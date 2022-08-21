using Microsoft.EntityFrameworkCore.Migrations;

namespace VaslavNijinskyOrgApp.Migrations
{
    public partial class TestAddPropertie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Choreography_ChoreographyId",
                table: "Participant");

            migrationBuilder.DropIndex(
                name: "IX_Participant_ChoreographyId",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "ChoreographyId",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "Participant");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Participant",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ChoreographyParticipant",
                columns: table => new
                {
                    ChoreographiesId = table.Column<int>(type: "INTEGER", nullable: false),
                    MembersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoreographyParticipant", x => new { x.ChoreographiesId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_ChoreographyParticipant_Choreography_ChoreographiesId",
                        column: x => x.ChoreographiesId,
                        principalTable: "Choreography",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChoreographyParticipant_Participant_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChoreographyParticipant_MembersId",
                table: "ChoreographyParticipant",
                column: "MembersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChoreographyParticipant");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Participant");

            migrationBuilder.AddColumn<int>(
                name: "ChoreographyId",
                table: "Participant",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventDate",
                table: "Participant",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participant_ChoreographyId",
                table: "Participant",
                column: "ChoreographyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Choreography_ChoreographyId",
                table: "Participant",
                column: "ChoreographyId",
                principalTable: "Choreography",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
