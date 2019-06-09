using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pizzaria_extra_api.Domains
{
    public partial class PizzariaContext : DbContext
    {
        public PizzariaContext()
        {
        }

        public PizzariaContext(DbContextOptions<PizzariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Pizzarias> Pizzarias { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuario { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DF1RBG4\\SQLSERVER;Database=PIZZARIA_EXTRA;integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.ToTable("CATEGORIAS");

                entity.HasIndex(e => e.NomeCategoria)
                    .HasName("UQ__CATEGORI__28E2A2F122CA9854")
                    .IsUnique();

                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.NomeCategoria)
                    .HasColumnName("NOME_CATEGORIA")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizzarias>(entity =>
            {
                entity.HasKey(e => e.IdPizzaria);

                entity.ToTable("PIZZARIAS");

                entity.HasIndex(e => e.Telefone)
                    .HasName("UQ__PIZZARIA__D6F1694F3509F7BD")
                    .IsUnique();

                entity.Property(e => e.IdPizzaria).HasColumnName("ID_PIZZARIA");

                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.NomePizzaria)
                    .HasColumnName("NOME_PIZZARIA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OpcaoVegana)
                    .HasColumnName("OPCAO_VEGANA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Telefone)
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Pizzarias)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__PIZZARIAS__ID_CA__6D0D32F4");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.ToTable("TIPOS_USUARIO");

                entity.HasIndex(e => e.NomeTipoUsuario)
                    .HasName("UQ__TIPOS_US__9028C46CCD1D8696")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.NomeTipoUsuario)
                    .HasColumnName("NOME_TIPO_USUARIO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.NomeUsuario)
                    .HasName("UQ__USUARIOS__E42F6250A05BE6E7")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.NomeUsuario)
                    .HasColumnName("NOME_USUARIO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasColumnName("SENHA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuario).HasColumnName("TIPO_USUARIO");

                entity.HasOne(d => d.TipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuario)
                    .HasConstraintName("FK__USUARIOS__TIPO_U__693CA210");
            });
        }
    }
}
