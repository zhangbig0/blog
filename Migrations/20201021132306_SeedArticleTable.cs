using Microsoft.EntityFrameworkCore.Migrations;

namespace blog.Migrations
{
    public partial class SeedArticleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { 1, "asp.net core", "hello world" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
