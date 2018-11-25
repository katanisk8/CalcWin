using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalcWin.DataAccess.Data.Migrations
{
    public partial class RemoveNormalizedNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NormalizedNames");

            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "Flavors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "Supplements",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "Fruits",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "Flavors",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "NormalizedNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Item = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalizedNames", x => x.Id);
                });
        }
    }
}
