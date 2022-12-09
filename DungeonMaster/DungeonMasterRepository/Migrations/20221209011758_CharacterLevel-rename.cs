using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungeonMasterRepository.Migrations
{
    /// <inheritdoc />
    public partial class CharacterLevelrename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Characters",
                newName: "CurrentLevel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentLevel",
                table: "Characters",
                newName: "Level");
        }
    }
}
