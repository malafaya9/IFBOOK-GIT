using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IFBOOK.Data.Migrations
{
    public partial class NotaAvaliacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nota",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "Disciplinas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Nota",
                table: "Professores",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Nota",
                table: "Disciplinas",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
