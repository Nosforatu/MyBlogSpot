using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlogApi.Migrations
{
    public partial class rename_id_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogEntryId",
                table: "BlogPosts",
                newName: "BlogPostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogPostId",
                table: "BlogPosts",
                newName: "BlogEntryId");
        }
    }
}
