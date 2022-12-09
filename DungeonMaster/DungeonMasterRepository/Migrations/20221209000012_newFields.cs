using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungeonMasterRepository.Migrations
{
    /// <inheritdoc />
    public partial class newFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttackModifier",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefenseModifier",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBreakable",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnchanted",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lore",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttackModifier",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DefenseModifier",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsBreakable",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsEnchanted",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Lore",
                table: "Items");
        }
    }
}
