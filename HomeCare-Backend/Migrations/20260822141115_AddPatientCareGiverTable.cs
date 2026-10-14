using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeCare.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientCareGiverTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientCareGivers",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    CareGiverId = table.Column<int>(type: "int", nullable: false),
                    DailyHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientCareGivers", x => new { x.PatientId, x.CareGiverId });
                    table.ForeignKey(
                        name: "FK_PatientCareGivers_CareGivers_CareGiverId",
                        column: x => x.CareGiverId,
                        principalTable: "CareGivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientCareGivers_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientCareGivers_CareGiverId",
                table: "PatientCareGivers",
                column: "CareGiverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientCareGivers");
        }
    }
}
