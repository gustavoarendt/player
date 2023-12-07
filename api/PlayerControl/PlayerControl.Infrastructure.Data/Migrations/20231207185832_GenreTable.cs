using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerControl.Infrastructure.Data.Migrations
{
    public partial class GenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    id_genre = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.id_genre);
                });

            migrationBuilder.CreateTable(
                name: "genre_category",
                columns: table => new
                {
                    id_genre_category = table.Column<Guid>(type: "uuid", nullable: false),
                    id_genre = table.Column<Guid>(type: "uuid", nullable: false),
                    id_category = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre_category", x => x.id_genre_category);
                    table.ForeignKey(
                        name: "FK_genre_category_category_id_category",
                        column: x => x.id_category,
                        principalTable: "category",
                        principalColumn: "id_category",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_genre_category_genre_id_genre",
                        column: x => x.id_genre,
                        principalTable: "genre",
                        principalColumn: "id_genre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_genre_category_id_category",
                table: "genre_category",
                column: "id_category");

            migrationBuilder.CreateIndex(
                name: "IX_genre_category_id_genre",
                table: "genre_category",
                column: "id_genre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "genre_category");

            migrationBuilder.DropTable(
                name: "genre");
        }
    }
}
