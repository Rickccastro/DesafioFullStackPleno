using Desafio.Domain.Entities;
using Desafio.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarefa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tarefas__3214EC071E228863");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DataCriacao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasConversion<string>() 
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
                .HasConversion<string>()
                .HasMaxLength(50)
                .HasDefaultValueSql($"'{Perfis.Usuario}'"); 
            entity.Property(e => e.Senha).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
