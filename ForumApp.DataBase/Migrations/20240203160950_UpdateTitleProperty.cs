using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApp.DataBase.Migrations
{
    public partial class UpdateTitleProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tilte",
                table: "Posts",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Posts",
                newName: "Tilte");
        }
    }
}
