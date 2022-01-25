using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using taanbus.domain.entities;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
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
            });

            modelBuilder.Entity<Sugerencia>(entity =>
            {
                entity.ToTable("sugerencia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApellidosCiudadano)
                    .HasColumnName("apellidos_ciudadano")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoCiudadano)
                    .HasColumnName("correo_ciudadano")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("fecha_registro")
                    .HasColumnType("date");

                entity.Property(e => e.NombreCiudadano)
                    .HasColumnName("nombre_ciudadano")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoCiudadano)
                    .HasColumnName("telefono_ciudadano")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
