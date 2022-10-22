using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineEvents.Migrations
{
    public partial class CreatingSourceIdinEventTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "SingleSource",
                table: "OnlineEvents");

            migrationBuilder.AddColumn<int>(
                name: "SourceId",
                table: "OnlineEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineEvents_PhotoAlbumId",
                table: "OnlineEvents",
                column: "PhotoAlbumId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineEvents_SourceId",
                table: "OnlineEvents",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineEvents_Sources_SourceId",
                table: "OnlineEvents",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineEvents_Sources_SourceId",
                table: "OnlineEvents");

            migrationBuilder.DropIndex(
                name: "IX_OnlineEvents_PhotoAlbumId",
                table: "OnlineEvents");

            migrationBuilder.DropIndex(
                name: "IX_OnlineEvents_SourceId",
                table: "OnlineEvents");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "OnlineEvents");

            migrationBuilder.AddColumn<int>(
                name: "PhotoAlbumId",
                table: "PhotoAlbum",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SingleSource",
                table: "OnlineEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoAlbum_PhotoAlbumId",
                table: "PhotoAlbum",
                column: "PhotoAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineEvents_PhotoAlbumId",
                table: "OnlineEvents",
                column: "PhotoAlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoAlbum_PhotoAlbum_PhotoAlbumId",
                table: "PhotoAlbum",
                column: "PhotoAlbumId",
                principalTable: "PhotoAlbum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
