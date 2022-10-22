using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineEvents.Migrations
{
    public partial class Test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                 name: "CategoryId",
                 table: "OnlineEvents",
                 type: "int",
                 nullable: false,
                 defaultValue: 0);

            //migrationbuilder.createindex(
            //    name: "ix_onlineevents_categoryid",
            //    table: "onlineevents",
            //    column: "categoryid");

            //migrationbuilder.addforeignkey(
            //    name: "fk_onlineevents_categories_categoryid",
            //    table: "onlineevents",
            //    column: "categoryid",
            //    principaltable: "categories",
            //    principalcolumn: "id",
            //    ondelete: referentialaction.cascade);

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
