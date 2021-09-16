using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkKanban.Core.Database.Migrations
{
    public partial class AddTypeToColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Column",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Column");
        }
    }
}
