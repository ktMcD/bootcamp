using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungeonMasterRepository.Migrations
{
    /// <inheritdoc />
    public partial class rebuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "CharacterItemRelationship",
                columns: table => new
                {
                    RelationshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterItemRelationship", x => x.RelationshipId);
                    table.ForeignKey(
                        name: "FK_CharacterItemRelationship_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterItemRelationship_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterItemRelationship_CharacterId",
                table: "CharacterItemRelationship",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterItemRelationship_ItemId",
                table: "CharacterItemRelationship",
                column: "ItemId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterItemRelationship");

        }
    }
}
