using Microsoft.EntityFrameworkCore.Migrations;

namespace CalcWin.DataAccess.Data.Migrations
{
    public partial class SuplementType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Supplements",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Supplements");
        }
    }
}
