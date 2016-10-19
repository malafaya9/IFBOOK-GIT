using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IFBOOK.Models;

namespace IFBOOK.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Sugestao> Sugestoes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<TipoAvaliacao> TipoAvaliacao { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<ProfessorDisciplina> ProfessorDisciplina { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().HasAlternateKey(u => u.Matricula);
            builder.Entity<ApplicationUser>().HasOne(u => u.Curso).WithMany(c => c.Alunos).HasForeignKey(u => u.CursoID).HasPrincipalKey(c => c.ID);

            builder.Entity<Sugestao>().HasOne(s => s.Usuario).WithMany(u => u.Sugestoes).HasForeignKey(s => s.UsuarioID).HasPrincipalKey(u => u.Id);

            builder.Entity<Evento>().HasOne(e => e.Usuario).WithMany(u => u.Eventos).HasForeignKey(e => e.UsuarioID).HasPrincipalKey(u => u.Id);
            builder.Entity<Evento>().Property<bool>(e => e.Status).ForSqlServerHasDefaultValue(false);

            builder.Entity<Pergunta>().HasOne(p => p.Curso).WithMany(c => c.Perguntas).HasForeignKey(p => p.CursoID).HasPrincipalKey(c => c.ID);
            builder.Entity<Pergunta>().HasOne(p => p.Usuario).WithMany(u => u.Perguntas).HasForeignKey(p => p.UsuarioID).HasPrincipalKey(u => u.Id);
            builder.Entity<Pergunta>().HasOne(p => p.Resposta).WithOne(r => r.Pergunta).HasForeignKey<Resposta>(r => r.PerguntaID).HasPrincipalKey<Pergunta>(p => p.ID);

            builder.Entity<Resposta>().HasOne(r => r.Usuario).WithMany(u => u.Respostas).HasForeignKey(r => r.UsuarioID).HasPrincipalKey(u => u.Id);

            builder.Entity<Publicacao>().HasOne(p => p.Usuario).WithMany(u => u.Publicacoes).HasForeignKey(p => p.UsuarioID).HasPrincipalKey(u => u.Id);

            builder.Entity<Comentario>().HasOne(c => c.Usuario).WithMany(u => u.Comentarios).HasForeignKey(c => c.UsuarioID).HasPrincipalKey(u => u.Id);
            builder.Entity<Comentario>().HasOne(c => c.Publicacao).WithMany(p => p.Comentarios).HasForeignKey(c => c.PublicacaoID).HasPrincipalKey(p => p.ID);

            builder.Entity<ProfessorDisciplina>().HasAlternateKey(pd => new { pd.ProfessorID, pd.DisciplinaID });
            builder.Entity<ProfessorDisciplina>().HasOne(pd => pd.Professor).WithMany(p => p.ProfessorDisciplina).HasForeignKey(pd => pd.ProfessorID).HasPrincipalKey(p => p.ID);
            builder.Entity<ProfessorDisciplina>().HasOne(pd => pd.Disciplina).WithMany(d => d.ProfessorDisciplina).HasForeignKey(pd => pd.DisciplinaID).HasPrincipalKey(d => d.ID);

            builder.Entity<Avaliacao>().HasOne(a => a.TipoAvaliacao).WithMany(ta => ta.Avaliacoes).HasForeignKey(a => a.TipoAvaliacaoID).HasPrincipalKey(ta => ta.ID);
            builder.Entity<Avaliacao>().HasOne(a => a.Professor).WithMany(p => p.Avaliacoes).HasForeignKey(a => a.ProfessorID).HasPrincipalKey(p => p.ID);
            builder.Entity<Avaliacao>().HasOne(a => a.Disciplina).WithMany(d => d.Avaliacoes).HasForeignKey(a => a.DisciplinaID).HasPrincipalKey(d => d.ID);
            builder.Entity<Avaliacao>().HasOne(a => a.Usuario).WithMany(u => u.Avaliacoes).HasForeignKey(a => a.UsuarioID).HasPrincipalKey(u => u.Id);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
