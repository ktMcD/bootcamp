using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungeonMasterRepository.Migrations
{
    /// <inheritdoc />
    public partial class CharacterRaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterRaceId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CharacterRaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterRaces", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterRaceId",
                table: "Characters",
                column: "CharacterRaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterRaces_CharacterRaceId",
                table: "Characters",
                column: "CharacterRaceId",
                principalTable: "CharacterRaces",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterRaces_CharacterRaceId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "CharacterRaces");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CharacterRaceId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CharacterRaceId",
                table: "Characters");
        }
    }
}
