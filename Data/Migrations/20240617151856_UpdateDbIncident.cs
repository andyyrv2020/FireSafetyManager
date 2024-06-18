using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireSafetyManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbIncident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Incidents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_EmployeeId",
                table: "Incidents",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Employees_EmployeeId",
                table: "Incidents",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Employees_EmployeeId",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_EmployeeId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Incidents");
        }
    }
}
