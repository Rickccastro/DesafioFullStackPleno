using System;
using System.Collections.Generic;
using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infraestructure.DataAccess;

public partial class DesafioDbContext : DbContext
{
    public DesafioDbContext()
    {
    }

    public DesafioDbContext(DbContextOptions<DesafioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tarefa> Tarefas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=DesafioPlenoFullStackPleno;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarefa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tarefas__3214EC071E228863");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DataCriacao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pendente");
            entity.Property(e => e.Titulo).HasMaxLength(200);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Tarefas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Tarefas_Usuarios");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07BF091E5B");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D105341639E2B6").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Nome).HasMaxLength(200);
            entity.Property(e => e.Perfil)
                .HasMaxLength(50)
                .HasDefaultValue("USUARIO");
            entity.Property(e => e.Senha).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
