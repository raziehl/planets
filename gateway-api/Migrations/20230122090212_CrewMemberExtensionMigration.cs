using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gatewayapi.Migrations
{
    /// <inheritdoc />
    public partial class CrewMemberExtensionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CrewMembers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "CrewMembers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "CrewMembers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Species",
                table: "CrewMembers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "CrewMembers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "CrewMembers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "CrewMembers");

            migrationBuilder.DropColumn(
                name: "Species",
                table: "CrewMembers");
        }
    }
}
