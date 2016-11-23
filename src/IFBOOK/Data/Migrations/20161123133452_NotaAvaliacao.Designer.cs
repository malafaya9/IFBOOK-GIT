using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IFBOOK.Data;

namespace IFBOOK.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161123133452_NotaAvaliacao")]
    partial class NotaAvaliacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IFBOOK.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("CursoID");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 14);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasAlternateKey("Matricula");

                    b.HasIndex("CursoID");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("IFBOOK.Models.Avaliacao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 500);

                    b.Property<int?>("DisciplinaID");

                    b.Property<int>("Nota");

                    b.Property<int?>("ProfessorID");

                    b.Property<int>("TipoAvaliacaoID");

                    b.Property<string>("UsuarioID");

                    b.HasKey("ID");

                    b.HasIndex("DisciplinaID");

                    b.HasIndex("ProfessorID");

                    b.HasIndex("TipoAvaliacaoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("IFBOOK.Models.Comentario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 500);

                    b.Property<int>("PublicacaoID");

                    b.Property<string>("UsuarioID");

                    b.HasKey("ID");

                    b.HasIndex("PublicacaoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("IFBOOK.Models.Curso", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 60);

                    b.HasKey("ID");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("IFBOOK.Models.Disciplina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Nome")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("ID");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("IFBOOK.Models.Evento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 60);

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:DefaultValue", false);

                    b.Property<string>("UsuarioID");

                    b.HasKey("ID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("IFBOOK.Models.Pergunta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CursoID");

                    b.Property<DateTime>("Data")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 500);

                    b.Property<bool>("Status");

                    b.Property<string>("UsuarioID");

                    b.HasKey("ID");

                    b.HasIndex("CursoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Perguntas");
                });

            modelBuilder.Entity("IFBOOK.Models.Professor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Nome")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("ID");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("IFBOOK.Models.ProfessorDisciplina", b =>
                {
                    b.Property<int>("ProfessorID");

                    b.Property<int>("DisciplinaID");

                    b.HasKey("ProfessorID", "DisciplinaID");

                    b.HasIndex("DisciplinaID");

                    b.HasIndex("ProfessorID");

                    b.ToTable("ProfessorDisciplina");
                });

            modelBuilder.Entity("IFBOOK.Models.Publicacao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("UsuarioID");

                    b.HasKey("ID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Publicacoes");
                });

            modelBuilder.Entity("IFBOOK.Models.Resposta", b =>
                {
                    b.Property<int>("PerguntaID");

                    b.Property<DateTime>("Data")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("UsuarioID");

                    b.HasKey("PerguntaID");

                    b.HasIndex("PerguntaID")
                        .IsUnique();

                    b.HasIndex("UsuarioID");

                    b.ToTable("Respostas");
                });

            modelBuilder.Entity("IFBOOK.Models.Sugestao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("UsuarioID");

                    b.HasKey("ID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Sugestoes");
                });

            modelBuilder.Entity("IFBOOK.Models.TipoAvaliacao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("ID");

                    b.ToTable("TipoAvaliacao");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("IFBOOK.Models.ApplicationUser", b =>
                {
                    b.HasOne("IFBOOK.Models.Curso", "Curso")
                        .WithMany("Alunos")
                        .HasForeignKey("CursoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IFBOOK.Models.Avaliacao", b =>
                {
                    b.HasOne("IFBOOK.Models.Disciplina", "Disciplina")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("DisciplinaID");

                    b.HasOne("IFBOOK.Models.Professor", "Professor")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("ProfessorID");

                    b.HasOne("IFBOOK.Models.TipoAvaliacao", "TipoAvaliacao")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("TipoAvaliacaoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IFBOOK.Models.ApplicationUser", "Usuario")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("UsuarioID");
                });

            modelBuilder.Entity("IFBOOK.Models.Comentario", b =>
                {
                    b.HasOne("IFBOOK.Models.Publicacao", "Publicacao")
                        .WithMany("Comentarios")
                        .HasForeignKey("PublicacaoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IFBOOK.Models.ApplicationUser", "Usuario")
                        .WithMany("Comentarios")
                        .HasForeignKey("UsuarioID");
                });

            modelBuilder.Entity("IFBOOK.Models.Evento", b =>
                {
                    b.HasOne("IFBOOK.Models.ApplicationUser", "Usuario")
                        .WithMany("Eventos")
                        .HasForeignKey("UsuarioID");
                });

            modelBuilder.Entity("IFBOOK.Models.Pergunta", b =>
                {
                    b.HasOne("IFBOOK.Models.Curso", "Curso")
                        .WithMany("Perguntas")
                        .HasForeignKey("CursoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IFBOOK.Models.ApplicationUser", "Usuario")
                        .WithMany("Perguntas")
                        .HasForeignKey("UsuarioID");
                });

            modelBuilder.Entity("IFBOOK.Models.ProfessorDisciplina", b =>
                {
                    b.HasOne("IFBOOK.Models.Disciplina", "Disciplina")
                        .WithMany("ProfessorDisciplina")
                        .HasForeignKey("DisciplinaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IFBOOK.Models.Professor", "Professor")
                        .WithMany("ProfessorDisciplina")
                        .HasForeignKey("ProfessorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IFBOOK.Models.Publicacao", b =>
                {
                    b.HasOne("IFBOOK.Models.ApplicationUser", "Usuario")
                        .WithMany("Publicacoes")
                        .HasForeignKey("UsuarioID");
                });

            modelBuilder.Entity("IFBOOK.Models.Resposta", b =>
                {
                    b.HasOne("IFBOOK.Models.Pergunta", "Pergunta")
                        .WithOne("Resposta")
                        .HasForeignKey("IFBOOK.Models.Resposta", "PerguntaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IFBOOK.Models.ApplicationUser", "Usuario")
                        .WithMany("Respostas")
                        .HasForeignKey("UsuarioID");
                });

            modelBuilder.Entity("IFBOOK.Models.Sugestao", b =>
                {
                    b.HasOne("IFBOOK.Models.ApplicationUser", "Usuario")
                        .WithMany("Sugestoes")
                        .HasForeignKey("UsuarioID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("IFBOOK.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("IFBOOK.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IFBOOK.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
