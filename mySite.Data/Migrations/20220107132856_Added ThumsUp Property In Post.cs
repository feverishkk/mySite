using Microsoft.EntityFrameworkCore.Migrations;

namespace mySite.Data.Migrations
{
    public partial class AddedThumsUpPropertyInPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThumbsUp",
                table: "Posts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbsUp",
                table: "Posts");
        }
    }
}
