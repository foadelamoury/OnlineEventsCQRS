using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineEvents.Migrations
{
    public partial class EventPhotoAlbumId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhotoAlbumId",
                table: "PhotoAlbum",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhotoAlbumId",
                table: "OnlineEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PhotoAlbum_PhotoAlbumId",
                table: "PhotoAlbum",
                column: "PhotoAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineEvents_PhotoAlbumId",
                table: "OnlineEvents",
                column: "PhotoAlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineEvents_PhotoAlbum_PhotoAlbumId",
                table: "OnlineEvents",
                column: "PhotoAlbumId",
                principalTable: "PhotoAlbum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoAlbum_PhotoAlbum_PhotoAlbumId",
                table: "PhotoAlbum",
                column: "PhotoAlbumId",
                principalTable: "PhotoAlbum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineEvents_PhotoAlbum_PhotoAlbumId",
                table: "OnlineEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoAlbum_PhotoAlbum_PhotoAlbumId",
                table: "PhotoAlbum");

            migrationBuilder.DropIndex(
                name: "IX_PhotoAlbum_PhotoAlbumId",
                table: "PhotoAlbum");

            migrationBuilder.DropIndex(
                name: "IX_OnlineEvents_PhotoAlbumId",
                table: "OnlineEvents");

            migrationBuilder.DropColumn(
                name: "PhotoAlbumId",
                table: "PhotoAlbum");

            migrationBuilder.DropColumn(
                name: "PhotoAlbumId",
                table: "OnlineEvents");
        }
    }
}
