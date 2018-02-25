using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CalcWin.Migrations
{
    public partial class SupplementType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Supplement");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Supplement");

            migrationBuilder.AddColumn<int>(
                name: "ParametersId",
                table: "Supplement",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SupplementType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplement_ParametersId",
                table: "Supplement",
                column: "ParametersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplement_SupplementType_ParametersId",
                table: "Supplement",
                column: "ParametersId",
                principalTable: "SupplementType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplement_SupplementType_ParametersId",
                table: "Supplement");

            migrationBuilder.DropTable(
                name: "SupplementType");

            migrationBuilder.DropIndex(
                name: "IX_Supplement_ParametersId",
                table: "Supplement");

            migrationBuilder.DropColumn(
                name: "ParametersId",
                table: "Supplement");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Supplement",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Supplement",
                nullable: false,
                defaultValue: 0);
        }
    }
}
