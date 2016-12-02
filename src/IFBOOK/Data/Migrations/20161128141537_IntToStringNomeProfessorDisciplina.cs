using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IFBOOK.Data.Migrations
{
    public partial class IntToStringNomeProfessorDisciplina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Professores",
                maxLength: 100,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Disciplinas",
                maxLength: 100,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Nome",
                table: "Professores",
                maxLength: 100,
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Nome",
                table: "Disciplinas",
                maxLength: 100,
                nullable: false);
        }
    }
}
