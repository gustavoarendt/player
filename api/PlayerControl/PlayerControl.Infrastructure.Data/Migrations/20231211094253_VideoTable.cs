using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerControl.Infrastructure.Data.Migrations
{
    public partial class VideoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "video",
                columns: table => new
                {
                    id_video = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    is_active = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    duration = table.Column<int>(type: "integer", nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    image_path = table.Column<string>(type: "text", nullable: true),
                    file_path = table.Column<string>(type: "text", nullable: true),
                    encoded_path = table.Column<string>(type: "text", nullable: true),
                    Media_Status = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video", x => x.id_video);
                });

            migrationBuilder.CreateTable(
                name: "VideoCategories",
                columns: table => new
                {
                    VideoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCategories", x => new { x.VideoId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_VideoCategories_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "id_category",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoCategories_video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "video",
                        principalColumn: "id_video",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoGenres",
                columns: table => new
                {
                    VideoId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGenres", x => new { x.VideoId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_VideoGenres_genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genre",
                        principalColumn: "id_genre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGenres_video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "video",
                        principalColumn: "id_video",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoCategories_CategoryId",
                table: "VideoCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGenres_GenreId",
                table: "VideoGenres",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoCategories");

            migrationBuilder.DropTable(
                name: "VideoGenres");

            migrationBuilder.DropTable(
                name: "video");
        }
    }
}
