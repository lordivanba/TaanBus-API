using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using taanbus.Domain.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace taanbus.Infrastructure.Data
{
    public partial class taanbusdbContext : DbContext
    {
        public taanbusdbContext()
        {
        }

        public taanbusdbContext(DbContextOptions<taanbusdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Queja> Queja { get; set; }
        public virtual DbSet<Sugerencia> Sugerencia { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("workstation id=taanbusdb.mssql.somee.com;packet size=4096;user id=lordivanba_SQLLogin_1;pwd=a9xd1c76va;data source=taanbusdb.mssql.somee.com;persist security info=False;initial catalog=taanbusdb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Queja>(entity =>
            {
                entity.ToTable("queja");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaHechos)
                    .HasColumnName("fecha_hechos")
                    .HasColumnType("date");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("fecha_registro")
                    .HasColumnType("date");

                entity.Property(e => e.MotivoQueja)
                    .HasColumnName("motivo_queja")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Queja)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__queja__user_id__3C69FB99");
            });

            modelBuilder.Entity<Sugerencia>(entity =>
            {
                entity.ToTable("sugerencia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("fecha_registro")
                    .HasColumnType("date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sugerencia)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__sugerenci__user___3F466844");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasColumnName("apellidos")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usertype).HasColumnName("usertype");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
