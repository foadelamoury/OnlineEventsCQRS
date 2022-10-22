using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineEvents.Migrations
{
    public partial class CreatingPhotoAlbumId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhotoAlbumId",
                table: "Image",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Image_PhotoAlbumId",
                table: "Image",
                column: "PhotoAlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_PhotoAlbum_PhotoAlbumId",
                table: "Image",
                column: "PhotoAlbumId",
                principalTable: "PhotoAlbum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_PhotoAlbum_PhotoAlbumId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_PhotoAlbumId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "PhotoAlbumId",
                table: "Image");
        }
    }
}
