using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerControl.Infrastructure.Data.Migrations
{
    public partial class TablePatternRefact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "video_genre",
                newName: "id_genre");

            migrationBuilder.RenameColumn(
                name: "VideoId",
                table: "video_genre",
                newName: "id_video");

            migrationBuilder.RenameIndex(
                name: "IX_video_genre_GenreId",
                table: "video_genre",
                newName: "IX_video_genre_id_genre");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "video_category",
                newName: "id_category");

            migrationBuilder.RenameColumn(
                name: "VideoId",
                table: "video_category",
                newName: "id_video");

            migrationBuilder.RenameIndex(
                name: "IX_video_category_CategoryId",
                table: "video_category",
                newName: "IX_video_category_id_category");

            migrationBuilder.RenameColumn(
                name: "Media_Status",
                table: "video",
                newName: "media_status");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "video",
                newName: "created_at");

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
                name: "FK_video_category_category_id_category",
                table: "video_category",
                column: "id_category",
                principalTable: "category",
                principalColumn: "id_category",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_video_category_video_id_video",
                table: "video_category",
                column: "id_video",
                principalTable: "video",
                principalColumn: "id_video",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_video_genre_genre_id_genre",
                table: "video_genre",
                column: "id_genre",
                principalTable: "genre",
                principalColumn: "id_genre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_video_genre_video_id_video",
                table: "video_genre",
                column: "id_video",
                principalTable: "video",
                principalColumn: "id_video",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_genre_category_category_id_category",
                table: "genre_category");

            migrationBuilder.DropForeignKey(
                name: "FK_genre_category_genre_id_genre",
                table: "genre_category");

            migrationBuilder.DropForeignKey(
                name: "FK_video_category_category_id_category",
                table: "video_category");

            migrationBuilder.DropForeignKey(
                name: "FK_video_category_video_id_video",
                table: "video_category");

            migrationBuilder.DropForeignKey(
                name: "FK_video_genre_genre_id_genre",
                table: "video_genre");

            migrationBuilder.DropForeignKey(
                name: "FK_video_genre_video_id_video",
                table: "video_genre");

            migrationBuilder.RenameColumn(
                name: "id_genre",
                table: "video_genre",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "id_video",
                table: "video_genre",
                newName: "VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_video_genre_id_genre",
                table: "video_genre",
                newName: "IX_video_genre_GenreId");

            migrationBuilder.RenameColumn(
                name: "id_category",
                table: "video_category",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "id_video",
                table: "video_category",
                newName: "VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_video_category_id_category",
                table: "video_category",
                newName: "IX_video_category_CategoryId");

            migrationBuilder.RenameColumn(
                name: "media_status",
                table: "video",
                newName: "Media_Status");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "video",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id_category",
                table: "genre_category",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "id_genre",
                table: "genre_category",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_genre_category_id_category",
                table: "genre_category",
                newName: "IX_genre_category_CategoryId");

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
    }
}
