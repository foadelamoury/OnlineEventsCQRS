using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineEvents.Migrations
{
    public partial class Test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "OnlineEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "OnlineEvents");
        }
    }
}
