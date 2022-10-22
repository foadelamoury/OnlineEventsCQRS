using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineEvents.Migrations
{
    public partial class CategoryIdUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OnlineEvents_CategoryId",
                table: "OnlineEvents",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineEvents_Categories_CategoryId",
                table: "OnlineEvents",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineEvents_Categories_CategoryId",
                table: "OnlineEvents");

            migrationBuilder.DropIndex(
                name: "IX_OnlineEvents_CategoryId",
                table: "OnlineEvents");
        }
    }
}
