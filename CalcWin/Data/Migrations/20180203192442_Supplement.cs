using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CalcWin.Migrations
{
    public partial class Supplement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplement_Projects_WineProjectId",
                table: "Supplement");

            migrationBuilder.DropIndex(
                name: "IX_Supplement_WineProjectId",
                table: "Supplement");

            migrationBuilder.DropColumn(
                name: "WineProjectId",
                table: "Supplement");

            migrationBuilder.AddColumn<string>(
                name: "WineProject",
                table: "Supplement",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WineProject",
                table: "Supplement");

            migrationBuilder.AddColumn<int>(
                name: "WineProjectId",
                table: "Supplement",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Supplement_WineProjectId",
                table: "Supplement",
                column: "WineProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplement_Projects_WineProjectId",
                table: "Supplement",
                column: "WineProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
