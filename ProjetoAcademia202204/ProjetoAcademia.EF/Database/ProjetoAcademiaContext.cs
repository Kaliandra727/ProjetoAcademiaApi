using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjetoAcademia.EF.Database
{
    public partial class ProjetoAcademiaContext : DbContext
    {
        public ProjetoAcademiaContext()
        {
        }

        public ProjetoAcademiaContext(DbContextOptions<ProjetoAcademiaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; } = null!;
        public virtual DbSet<AlunosPorTurma> AlunosPorTurmas { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<CursosPorTurma> CursosPorTurmas { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<Instrutor> Instrutors { get; set; } = null!;
        public virtual DbSet<InstrutoresPorTurma> InstrutoresPorTurmas { get; set; } = null!;
        public virtual DbSet<Periodo> Periodos { get; set; } = null!;
        public virtual DbSet<Turma> Turmas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=psgs0071.psg.local;Initial Catalog=ProjetoAcademia202204;User=academia;Password=@cadem1@555");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.IdAluno)
                    .HasName("PKIdAluno");

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AlunosPorTurma>(entity =>
            {
                entity.HasKey(e => e.IdAlunoTurma)
                    .HasName("PKIdAlunoTurma");

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PKIdCurso");

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CursosPorTurma>(entity =>
            {
                entity.HasKey(e => e.IdCursoTurma)
                    .HasName("PKIdCursoTurma");

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PKIdEndereco");

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Instrutor>(entity =>
            {
                entity.HasKey(e => e.IdInstrutor)
                    .HasName("PKIdInstrutor");

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<InstrutoresPorTurma>(entity =>
            {
                entity.HasKey(e => e.IdInstrutorTurma)
                    .HasName("PKIdInstrutorTurma");

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Periodo>(entity =>
            {
                entity.HasKey(e => e.IdPeriodo)
                    .HasName("PKIdPeriodo");

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.HasKey(e => e.IdTurma)
                    .HasName("PKIdTurma");

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PKIdUsuario");

                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
