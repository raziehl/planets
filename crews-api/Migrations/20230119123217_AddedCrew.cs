using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crewsapi.Migrations
{
    /// <inheritdoc />
    public partial class AddedCrew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrewId",
                table: "CrewMembers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CrewName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrewMembers_CrewId",
                table: "CrewMembers",
                column: "CrewId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrewMembers_Crews_CrewId",
                table: "CrewMembers",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrewMembers_Crews_CrewId",
                table: "CrewMembers");

            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.DropIndex(
                name: "IX_CrewMembers_CrewId",
                table: "CrewMembers");

            migrationBuilder.DropColumn(
                name: "CrewId",
                table: "CrewMembers");
        }
    }
}
