using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Champions.Migrations
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
