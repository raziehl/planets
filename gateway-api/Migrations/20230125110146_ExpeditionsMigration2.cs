using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gatewayapi.Migrations
{
    /// <inheritdoc />
    public partial class ExpeditionsMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expeditions_Expeditions_ExpeditionId",
                table: "Expeditions");

            migrationBuilder.DropIndex(
                name: "IX_Expeditions_ExpeditionId",
                table: "Expeditions");

            migrationBuilder.DropColumn(
                name: "ExpeditionId",
                table: "Expeditions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpeditionId",
                table: "Expeditions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expeditions_ExpeditionId",
                table: "Expeditions",
                column: "ExpeditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expeditions_Expeditions_ExpeditionId",
                table: "Expeditions",
                column: "ExpeditionId",
                principalTable: "Expeditions",
                principalColumn: "Id");
        }
    }
}
