using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IFBOOK.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<int>(maxLength: 100, nullable: false),
                    Nota = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Status = table.Column<bool>(nullable: false, defaultValue: false),
                    UsuarioID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Eventos_AspNetUsers_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<int>(maxLength: 100, nullable: false),
                    Nota = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publicacoes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    UsuarioID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicacoes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Publicacoes_AspNetUsers_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sugestoes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    UsuarioID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sugestoes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sugestoes_AspNetUsers_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoAvaliacao",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAvaliacao", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CursoID = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    UsuarioID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Perguntas_Cursos_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Cursos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perguntas_AspNetUsers_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorDisciplina",
                columns: table => new
                {
                    ProfessorID = table.Column<int>(nullable: false),
                    DisciplinaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorDisciplina", x => new { x.ProfessorID, x.DisciplinaID });
                    table.ForeignKey(
                        name: "FK_ProfessorDisciplina_Disciplinas_DisciplinaID",
                        column: x => x.DisciplinaID,
                        principalTable: "Disciplinas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorDisciplina_Professores_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Professores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    PublicacaoID = table.Column<int>(nullable: false),
                    UsuarioID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comentarios_Publicacoes_PublicacaoID",
                        column: x => x.PublicacaoID,
                        principalTable: "Publicacoes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_AspNetUsers_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    DisciplinaID = table.Column<int>(nullable: true),
                    Nota = table.Column<int>(nullable: false),
                    ProfessorID = table.Column<int>(nullable: true),
                    TipoAvaliacaoID = table.Column<int>(nullable: false),
                    UsuarioID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Disciplinas_DisciplinaID",
                        column: x => x.DisciplinaID,
                        principalTable: "Disciplinas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Professores_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Professores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_TipoAvaliacao_TipoAvaliacaoID",
                        column: x => x.TipoAvaliacaoID,
                        principalTable: "TipoAvaliacao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_AspNetUsers_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    PerguntaID = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    UsuarioID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => x.PerguntaID);
                    table.ForeignKey(
                        name: "FK_Respostas_Perguntas_PerguntaID",
                        column: x => x.PerguntaID,
                        principalTable: "Perguntas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Respostas_AspNetUsers_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "CursoID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "AspNetUsers",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_Matricula",
                table: "AspNetUsers",
                column: "Matricula");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CursoID",
                table: "AspNetUsers",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_DisciplinaID",
                table: "Avaliacoes",
                column: "DisciplinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ProfessorID",
                table: "Avaliacoes",
                column: "ProfessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_TipoAvaliacaoID",
                table: "Avaliacoes",
                column: "TipoAvaliacaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_UsuarioID",
                table: "Avaliacoes",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PublicacaoID",
                table: "Comentarios",
                column: "PublicacaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuarioID",
                table: "Comentarios",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_UsuarioID",
                table: "Eventos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_CursoID",
                table: "Perguntas",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_UsuarioID",
                table: "Perguntas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorDisciplina_DisciplinaID",
                table: "ProfessorDisciplina",
                column: "DisciplinaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorDisciplina_ProfessorID",
                table: "ProfessorDisciplina",
                column: "ProfessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_UsuarioID",
                table: "Publicacoes",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_PerguntaID",
                table: "Respostas",
                column: "PerguntaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_UsuarioID",
                table: "Respostas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Sugestoes_UsuarioID",
                table: "Sugestoes",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cursos_CursoID",
                table: "AspNetUsers",
                column: "CursoID",
                principalTable: "Cursos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cursos_CursoID",
                table: "AspNetUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_Matricula",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CursoID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CursoID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "ProfessorDisciplina");

            migrationBuilder.DropTable(
                name: "Respostas");

            migrationBuilder.DropTable(
                name: "Sugestoes");

            migrationBuilder.DropTable(
                name: "TipoAvaliacao");

            migrationBuilder.DropTable(
                name: "Publicacoes");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Perguntas");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
