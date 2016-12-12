using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IFBOOK.Data.Migrations
{
    public partial class NoDescricaoAvaliacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Avaliacoes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Avaliacoes",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
