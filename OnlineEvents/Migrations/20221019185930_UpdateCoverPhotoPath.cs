using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineEvents.Migrations
{
    public partial class UpdateCoverPhotoPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPhotoPath",
                table: "OnlineEvents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<string>(
              name: "CoverPhotoPath",
              table: "OnlineEvents",
              type: "nvarchar(max)",
              nullable: false,
              defaultValue: "");
        }
    }
}
