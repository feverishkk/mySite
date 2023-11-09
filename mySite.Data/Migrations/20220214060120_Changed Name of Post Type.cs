using Microsoft.EntityFrameworkCore.Migrations;

namespace mySite.Data.Migrations
{
    public partial class ChangedNameofPostType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "postType",
                table: "Posts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "postType",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
