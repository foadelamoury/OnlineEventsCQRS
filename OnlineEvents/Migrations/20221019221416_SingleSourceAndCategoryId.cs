using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineEvents.Migrations
{
    public partial class SingleSourceAndCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
              name: "SingleSource",
              table: "OnlineEvents",
              type: "nvarchar(max)",
              nullable: false,
              defaultValue: "");


            migrationBuilder.AddColumn<int>(
              name: "CategoryId",
              table: "OnlineEvents",
              type: "int",
              nullable: false,
              defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
