using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsoleChampions.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
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
                name: "RuneEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Family = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuneEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunePageEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunePageEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillEntity", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "ChampionEntityRunePageEntity",
                columns: table => new
                {
                    ChampionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    RunePagesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionEntityRunePageEntity", x => new { x.ChampionsId, x.RunePagesId });
                    table.ForeignKey(
                        name: "FK_ChampionEntityRunePageEntity_ChampionEntity_ChampionsId",
                        column: x => x.ChampionsId,
                        principalTable: "ChampionEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChampionEntityRunePageEntity_RunePageEntity_RunePagesId",
                        column: x => x.RunePagesId,
                        principalTable: "RunePageEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RuneEntityRunePageEntity",
                columns: table => new
                {
                    RunePagesId = table.Column<int>(type: "INTEGER", nullable: false),
                    RunesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuneEntityRunePageEntity", x => new { x.RunePagesId, x.RunesId });
                    table.ForeignKey(
                        name: "FK_RuneEntityRunePageEntity_RuneEntity_RunesId",
                        column: x => x.RunesId,
                        principalTable: "RuneEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RuneEntityRunePageEntity_RunePageEntity_RunePagesId",
                        column: x => x.RunePagesId,
                        principalTable: "RunePageEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChampionEntitySkillEntity",
                columns: table => new
                {
                    ChampionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionEntitySkillEntity", x => new { x.ChampionsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_ChampionEntitySkillEntity_ChampionEntity_ChampionsId",
                        column: x => x.ChampionsId,
                        principalTable: "ChampionEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChampionEntitySkillEntity_SkillEntity_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "SkillEntity",
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
                table: "RuneEntity",
                columns: new[] { "Id", "Description", "Family", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Conqueror" },
                    { 2, null, null, "Triumph" },
                    { 3, null, null, "Legend: Alacrity" },
                    { 4, null, null, "Legend: Tenacity" },
                    { 5, null, null, "last stand" },
                    { 6, null, null, "last stand 2" }
                });

            migrationBuilder.InsertData(
                table: "RunePageEntity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "RunePage1" },
                    { 2, "RunePage2" }
                });

            migrationBuilder.InsertData(
                table: "SkillEntity",
                columns: new[] { "Id", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, null, "FirePower", 1 },
                    { 2, null, "MentalStrenght", 2 },
                    { 3, null, "UltimEnd", 3 }
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
                name: "IX_ChampionEntityRunePageEntity_RunePagesId",
                table: "ChampionEntityRunePageEntity",
                column: "RunePagesId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionEntitySkillEntity_SkillsId",
                table: "ChampionEntitySkillEntity",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_RuneEntityRunePageEntity_RunesId",
                table: "RuneEntityRunePageEntity",
                column: "RunesId");

            migrationBuilder.CreateIndex(
                name: "IX_SkinEntity_ForeignChampion",
                table: "SkinEntity",
                column: "ForeignChampion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampionEntityRunePageEntity");

            migrationBuilder.DropTable(
                name: "ChampionEntitySkillEntity");

            migrationBuilder.DropTable(
                name: "RuneEntityRunePageEntity");

            migrationBuilder.DropTable(
                name: "SkinEntity");

            migrationBuilder.DropTable(
                name: "SkillEntity");

            migrationBuilder.DropTable(
                name: "RuneEntity");

            migrationBuilder.DropTable(
                name: "RunePageEntity");

            migrationBuilder.DropTable(
                name: "ChampionEntity");
        }
    }
}
