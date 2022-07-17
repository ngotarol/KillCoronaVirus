using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FCE_KillCoronaVirus.Models
{
    public partial class KillCoronaVirusContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public KillCoronaVirusContext()
        {
        }

        public KillCoronaVirusContext(DbContextOptions<KillCoronaVirusContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; } = null!;
        public virtual DbSet<Atencion> Atencions { get; set; } = null!;
        public virtual DbSet<DetalleOrden> DetalleOrdens { get; set; } = null!;
        public virtual DbSet<DetalleRecetum> DetalleReceta { get; set; } = null!;
        public virtual DbSet<EspecialidadMedico> EspecialidadMedicos { get; set; } = null!;
        public virtual DbSet<Especialidad> Especilidads { get; set; } = null!;
        public virtual DbSet<Examan> Examen { get; set; } = null!;
        public virtual DbSet<Farmaco> Farmacos { get; set; } = null!;
        public virtual DbSet<Orden> Ordens { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<PresentacionFarmaco> PresentacionFarmacos { get; set; } = null!;
        public virtual DbSet<Recetum> Receta { get; set; } = null!;
        public virtual DbSet<Sexo> Sexos { get; set; } = null!;
        public virtual DbSet<TipoExaman> TipoExamen { get; set; } = null!;
        public virtual DbSet<UnidadDeMedidum> UnidadDeMedida { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:KillCoronaVirus");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atencion>(entity =>
            {
                entity.HasKey(e => e.NroAtencion);

                entity.ToTable("Atencion");

                entity.Property(e => e.NroAtencion).HasColumnName("nroAtencion");

                entity.Property(e => e.DatAtencion)
                    .HasColumnType("text")
                    .HasColumnName("datAtencion");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_hora");

                entity.Property(e => e.IdPac).HasColumnName("idPac");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdPacNavigation)
                    .WithMany(p => p.Atencions)
                    .HasForeignKey(d => d.IdPac)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Atencion_Paciente");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Atencions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Atencion_Usuarios");
            });

            modelBuilder.Entity<DetalleOrden>(entity =>
            {
                entity.HasKey(e => e.IdDetOrden);

                entity.ToTable("detalleOrden");

                entity.Property(e => e.IdDetOrden).HasColumnName("idDetOrden");

                entity.Property(e => e.CodExa).HasColumnName("codExa");

                entity.Property(e => e.NroOrden).HasColumnName("nroOrden");

                entity.HasOne(d => d.CodExaNavigation)
                    .WithMany(p => p.DetalleOrdens)
                    .HasForeignKey(d => d.CodExa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalleOrden_Examen");

                entity.HasOne(d => d.NroOrdenNavigation)
                    .WithMany(p => p.DetalleOrdens)
                    .HasForeignKey(d => d.NroOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalleOrden_Orden");
            });

            modelBuilder.Entity<DetalleRecetum>(entity =>
            {
                entity.HasKey(e => e.IdDetReceta);

                entity.ToTable("detalleReceta");

                entity.Property(e => e.IdDetReceta).HasColumnName("idDetReceta");

                entity.Property(e => e.CodFar).HasColumnName("codFar");

                entity.Property(e => e.Dosis)
                    .HasColumnType("text")
                    .HasColumnName("dosis");

                entity.Property(e => e.NroReceta).HasColumnName("nroReceta");

                entity.HasOne(d => d.CodFarNavigation)
                    .WithMany(p => p.DetalleReceta)
                    .HasForeignKey(d => d.CodFar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalleReceta_Farmaco");

                entity.HasOne(d => d.NroRecetaNavigation)
                    .WithMany(p => p.DetalleReceta)
                    .HasForeignKey(d => d.NroReceta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalleReceta_Receta");
            });

            modelBuilder.Entity<EspecialidadMedico>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EspecialidadMedico");

                entity.Property(e => e.CodEsp).HasColumnName("codEsp");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.CodEspNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodEsp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EspecialidadMedico_Especilidad");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EspecialidadMedico_Usuarios");
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.CodEsp);

                entity.ToTable("Especialidad");

                entity.Property(e => e.CodEsp).HasColumnName("codEsp");

                entity.Property(e => e.NomEsp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomEsp");
            });

            modelBuilder.Entity<Examan>(entity =>
            {
                entity.HasKey(e => e.CodExa);

                entity.Property(e => e.CodExa).HasColumnName("codExa");

                entity.Property(e => e.CodTipo).HasColumnName("codTipo");

                entity.Property(e => e.NomExa)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomExa");

                entity.HasOne(d => d.CodTipoNavigation)
                    .WithMany(p => p.Examen)
                    .HasForeignKey(d => d.CodTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Examen_TipoExamen");
            });

            modelBuilder.Entity<Farmaco>(entity =>
            {
                entity.HasKey(e => e.CodFar);

                entity.ToTable("Farmaco");

                entity.Property(e => e.CodFar).HasColumnName("codFar");

                entity.Property(e => e.CodPresentacion).HasColumnName("codPresentacion");

                entity.Property(e => e.CodUom).HasColumnName("codUOM");

                entity.Property(e => e.Concentracion).HasColumnName("concentracion");

                entity.Property(e => e.NomFar)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomFar");

                entity.HasOne(d => d.CodPresentacionNavigation)
                    .WithMany(p => p.Farmacos)
                    .HasForeignKey(d => d.CodPresentacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Farmaco_PresentacionFarmaco");

                entity.HasOne(d => d.CodUomNavigation)
                    .WithMany(p => p.Farmacos)
                    .HasForeignKey(d => d.CodUom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Farmaco_UnidadDeMedida");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasKey(e => e.NroOrden);

                entity.ToTable("Orden");

                entity.Property(e => e.NroOrden).HasColumnName("nroOrden");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdPac).HasColumnName("idPac");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NroAtencion).HasColumnName("nroAtencion");

                entity.HasOne(d => d.IdPacNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.IdPac)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orden_Paciente");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orden_Usuarios");

                entity.HasOne(d => d.NroAtencionNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.NroAtencion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orden_Atencion");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPac);

                entity.ToTable("Paciente");

                entity.Property(e => e.IdPac).HasColumnName("idPac");

                entity.Property(e => e.CodSexo).HasColumnName("codSexo");

                entity.Property(e => e.EdadPac).HasColumnName("edadPac");

                entity.Property(e => e.FecNacPac)
                    .HasColumnType("date")
                    .HasColumnName("fecNacPac");

                entity.Property(e => e.NomPac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomPac");

                entity.Property(e => e.RutPac).HasColumnName("rutPac");

                entity.HasOne(d => d.CodSexoNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.CodSexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paciente_Sexo");
            });

            modelBuilder.Entity<PresentacionFarmaco>(entity =>
            {
                entity.HasKey(e => e.CodPresentacion);

                entity.ToTable("PresentacionFarmaco");

                entity.Property(e => e.CodPresentacion).HasColumnName("codPresentacion");

                entity.Property(e => e.NomPresentacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomPresentacion");
            });

            modelBuilder.Entity<Recetum>(entity =>
            {
                entity.HasKey(e => e.NroReceta);

                entity.Property(e => e.NroReceta).HasColumnName("nroReceta");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdPac).HasColumnName("idPac");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NroAtencion).HasColumnName("nroAtencion");

                entity.HasOne(d => d.IdPacNavigation)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.IdPac)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receta_Paciente");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receta_Usuarios");

                entity.HasOne(d => d.NroAtencionNavigation)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.NroAtencion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receta_Atencion");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.HasKey(e => e.CodSexo);

                entity.ToTable("Sexo");

                entity.Property(e => e.CodSexo).HasColumnName("codSexo");

                entity.Property(e => e.NomSexo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomSexo");
            });

            modelBuilder.Entity<TipoExaman>(entity =>
            {
                entity.HasKey(e => e.CodTipo);

                entity.Property(e => e.CodTipo).HasColumnName("codTipo");

                entity.Property(e => e.NomTipo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomTipo");
            });

            modelBuilder.Entity<UnidadDeMedidum>(entity =>
            {
                entity.HasKey(e => e.CodUom);

                entity.Property(e => e.CodUom).HasColumnName("codUOM");

                entity.Property(e => e.NomUom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomUOM");
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.CodSexo).HasColumnName("codSexo");

                entity.HasOne(d => d.CodSexoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CodSexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Sexo");
            });
            base.OnModelCreating(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
