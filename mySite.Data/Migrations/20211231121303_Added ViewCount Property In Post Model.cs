using Microsoft.EntityFrameworkCore.Migrations;

namespace mySite.Data.Migrations
{
    public partial class AddedViewCountPropertyInPostModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Posts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Posts");
        }
    }
}
