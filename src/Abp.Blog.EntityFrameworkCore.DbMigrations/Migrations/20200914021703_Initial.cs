using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Abp.Blog.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "abp_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "abp_Friendlinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    LinkUrl = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_Friendlinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "abp_Post_Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_Post_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "abp_Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Author = table.Column<string>(maxLength: 10, nullable: true),
                    Url = table.Column<string>(maxLength: 100, nullable: false),
                    Html = table.Column<string>(type: "longtext", nullable: false),
                    Markdown = table.Column<string>(type: "longtext", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "abp_Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TagName = table.Column<string>(maxLength: 50, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abp_Tags", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abp_Categories");

            migrationBuilder.DropTable(
                name: "abp_Friendlinks");

            migrationBuilder.DropTable(
                name: "abp_Post_Tags");

            migrationBuilder.DropTable(
                name: "abp_Posts");

            migrationBuilder.DropTable(
                name: "abp_Tags");
        }
    }
}
