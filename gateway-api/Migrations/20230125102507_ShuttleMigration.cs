using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gatewayapi.Migrations
{
    /// <inheritdoc />
    public partial class ShuttleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShuttleName",
                table: "Crews",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShuttleName",
                table: "Crews");
        }
    }
}
