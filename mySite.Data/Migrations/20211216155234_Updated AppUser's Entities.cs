using Microsoft.EntityFrameworkCore.Migrations;

namespace mySite.Data.Migrations
{
    public partial class UpdatedAppUsersEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StreetAddress_3",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreetAddress_3",
                table: "AspNetUsers");
        }
    }
}
