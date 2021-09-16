using DarkKanban.Core.Database.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkKanban.Core.Database.Migrations
{
    public partial class DefaultBoardInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            MigrationHelper.InitDefaultBoard(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
