using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsApp.API.Migrations
{
    public partial class updateModelName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Values",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Values",
                newName: "MyProperty");
        }
    }
}
