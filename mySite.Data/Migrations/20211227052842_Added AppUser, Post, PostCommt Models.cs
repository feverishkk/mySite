﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mySite.Data.Migrations
{
    public partial class AddedAppUserPostPostCommtModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LatestLoginDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostComments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_PostId",
                table: "PostComments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_UserId",
                table: "PostComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropColumn(
                name: "LatestLoginDate",
                table: "AspNetUsers");
        }
    }
}
