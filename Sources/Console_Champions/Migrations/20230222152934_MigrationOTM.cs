﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsoleChampions.Migrations
{
    /// <inheritdoc />
    public partial class MigrationOTM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChampionEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Class = table.Column<int>(type: "INTEGER", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Bio = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkinEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<float>(type: "REAL", nullable: true),
                    ForeignChampion = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkinEntity_ChampionEntity_ForeignChampion",
                        column: x => x.ForeignChampion,
                        principalTable: "ChampionEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChampionEntity",
                columns: new[] { "Id", "Bio", "Class", "Icon", "Image", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, null, null, "Akali" },
                    { 2, null, 2, null, null, "Aatrox" },
                    { 3, null, 3, null, null, "Ahri" }
                });

            migrationBuilder.InsertData(
                table: "SkinEntity",
                columns: new[] { "Id", "Description", "ForeignChampion", "Icon", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, 1, null, null, "Stinger", null },
                    { 2, null, 1, null, null, "Infernal", null },
                    { 3, null, 1, null, null, "All-Star", null },
                    { 4, null, 2, null, null, "Justicar", null },
                    { 5, null, 2, null, null, "Mecha", null },
                    { 6, null, 2, null, null, "Sea Hunter", null },
                    { 7, null, 3, null, null, "Dynasty", null },
                    { 8, null, 3, null, null, "Midnight", null },
                    { 9, null, 3, null, null, "Foxfire", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkinEntity_ForeignChampion",
                table: "SkinEntity",
                column: "ForeignChampion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkinEntity");

            migrationBuilder.DropTable(
                name: "ChampionEntity");
        }
    }
}
