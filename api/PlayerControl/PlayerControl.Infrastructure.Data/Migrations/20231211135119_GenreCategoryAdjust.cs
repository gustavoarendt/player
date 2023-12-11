using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerControl.Infrastructure.Data.Migrations
{
    public partial class GenreCategoryAdjust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_genre_category_category_id_category",
                table: "genre_category");

            migrationBuilder.DropForeignKey(
                name: "FK_genre_category_genre_id_genre",
                table: "genre_category");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoCategories_category_CategoryId",
                table: "VideoCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoCategories_video_VideoId",
                table: "VideoCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoGenres_genre_GenreId",
                table: "VideoGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoGenres_video_VideoId",
                table: "VideoGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genre_category",
                table: "genre_category");

            migrationBuilder.DropIndex(
                name: "IX_genre_category_id_genre",
                table: "genre_category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoGenres",
                table: "VideoGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoCategories",
                table: "VideoCategories");

            migrationBuilder.DropColumn(
                name: "id_genre_category",
                table: "genre_category");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "genre_category");

            migrationBuilder.RenameTable(
                name: "VideoGenres",
                newName: "video_genre");

            migrationBuilder.RenameTable(
                name: "VideoCategories",
                newName: "video_category");

            migrationBuilder.RenameColumn(
                name: "id_genre",
                table: "genre_category",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "id_category",
                table: "genre_category",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_genre_category_id_category",
                table: "genre_category",
                newName: "IX_genre_category_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoGenres_GenreId",
                table: "video_genre",
                newName: "IX_video_genre_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoCategories_CategoryId",
                table: "video_category",
                newName: "IX_video_category_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genre_category",
                table: "genre_category",
                columns: new[] { "GenreId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_video_genre",
                table: "video_genre",
                columns: new[] { "VideoId", "GenreId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_video_category",
                table: "video_category",
                columns: new[] { "VideoId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_genre_category_category_CategoryId",
                table: "genre_category",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "id_category",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_genre_category_genre_GenreId",
                table: "genre_category",
                column: "GenreId",
                principalTable: "genre",
                principalColumn: "id_genre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_video_category_category_CategoryId",
                table: "video_category",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "id_category",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_video_category_video_VideoId",
                table: "video_category",
                column: "VideoId",
                principalTable: "video",
                principalColumn: "id_video",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_video_genre_genre_GenreId",
                table: "video_genre",
                column: "GenreId",
                principalTable: "genre",
                principalColumn: "id_genre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_video_genre_video_VideoId",
                table: "video_genre",
                column: "VideoId",
                principalTable: "video",
                principalColumn: "id_video",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_genre_category_category_CategoryId",
                table: "genre_category");

            migrationBuilder.DropForeignKey(
                name: "FK_genre_category_genre_GenreId",
                table: "genre_category");

            migrationBuilder.DropForeignKey(
                name: "FK_video_category_category_CategoryId",
                table: "video_category");

            migrationBuilder.DropForeignKey(
                name: "FK_video_category_video_VideoId",
                table: "video_category");

            migrationBuilder.DropForeignKey(
                name: "FK_video_genre_genre_GenreId",
                table: "video_genre");

            migrationBuilder.DropForeignKey(
                name: "FK_video_genre_video_VideoId",
                table: "video_genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genre_category",
                table: "genre_category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_video_genre",
                table: "video_genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_video_category",
                table: "video_category");

            migrationBuilder.RenameTable(
                name: "video_genre",
                newName: "VideoGenres");

            migrationBuilder.RenameTable(
                name: "video_category",
                newName: "VideoCategories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "genre_category",
                newName: "id_category");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "genre_category",
                newName: "id_genre");

            migrationBuilder.RenameIndex(
                name: "IX_genre_category_CategoryId",
                table: "genre_category",
                newName: "IX_genre_category_id_category");

            migrationBuilder.RenameIndex(
                name: "IX_video_genre_GenreId",
                table: "VideoGenres",
                newName: "IX_VideoGenres_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_video_category_CategoryId",
                table: "VideoCategories",
                newName: "IX_VideoCategories_CategoryId");

            migrationBuilder.AddColumn<Guid>(
                name: "id_genre_category",
                table: "genre_category",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "genre_category",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_genre_category",
                table: "genre_category",
                column: "id_genre_category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoGenres",
                table: "VideoGenres",
                columns: new[] { "VideoId", "GenreId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoCategories",
                table: "VideoCategories",
                columns: new[] { "VideoId", "CategoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_genre_category_id_genre",
                table: "genre_category",
                column: "id_genre");

            migrationBuilder.AddForeignKey(
                name: "FK_genre_category_category_id_category",
                table: "genre_category",
                column: "id_category",
                principalTable: "category",
                principalColumn: "id_category",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_genre_category_genre_id_genre",
                table: "genre_category",
                column: "id_genre",
                principalTable: "genre",
                principalColumn: "id_genre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoCategories_category_CategoryId",
                table: "VideoCategories",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "id_category",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoCategories_video_VideoId",
                table: "VideoCategories",
                column: "VideoId",
                principalTable: "video",
                principalColumn: "id_video",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGenres_genre_GenreId",
                table: "VideoGenres",
                column: "GenreId",
                principalTable: "genre",
                principalColumn: "id_genre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGenres_video_VideoId",
                table: "VideoGenres",
                column: "VideoId",
                principalTable: "video",
                principalColumn: "id_video",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
