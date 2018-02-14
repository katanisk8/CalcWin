using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CalcWin.Migrations
{
    public partial class ProjectColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fruits_Fruits_ParentId",
                table: "Fruits");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Projects_ProjectId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplement_Projects_WineProjectId",
                table: "Supplement");

            migrationBuilder.DropIndex(
                name: "IX_Supplement_WineProjectId",
                table: "Supplement");

            migrationBuilder.DropIndex(
                name: "IX_Fruits_ParentId",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "WineProjectId",
                table: "Supplement");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Fruits");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Supplement",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Supplement",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Ingredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Fruits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Flavors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_Supplement_ProjectId",
                table: "Supplement",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Projects_ProjectId",
                table: "Ingredients",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplement_Projects_ProjectId",
                table: "Supplement",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Projects_ProjectId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplement_Projects_ProjectId",
                table: "Supplement");

            migrationBuilder.DropIndex(
                name: "IX_Supplement_ProjectId",
                table: "Supplement");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Supplement");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Supplement",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WineProjectId",
                table: "Supplement",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Ingredients",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Fruits",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Fruits",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Flavors",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplement_WineProjectId",
                table: "Supplement",
                column: "WineProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Fruits_ParentId",
                table: "Fruits",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fruits_Fruits_ParentId",
                table: "Fruits",
                column: "ParentId",
                principalTable: "Fruits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Projects_ProjectId",
                table: "Ingredients",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplement_Projects_WineProjectId",
                table: "Supplement",
                column: "WineProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
