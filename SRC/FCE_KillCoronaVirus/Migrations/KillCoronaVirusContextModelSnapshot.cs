﻿// <auto-generated />
using System;
using FCE_KillCoronaVirus.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FCE_KillCoronaVirus.Migrations
{
    [DbContext(typeof(KillCoronaVirusContext))]
    partial class KillCoronaVirusContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ApMaterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApPaterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodSexo")
                        .HasColumnType("int")
                        .HasColumnName("codSexo");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CodSexo");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Atencion", b =>
                {
                    b.Property<int>("NroAtencion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("nroAtencion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NroAtencion"), 1L, 1);

                    b.Property<string>("DatAtencion")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("datAtencion");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_hora");

                    b.Property<int>("IdPac")
                        .HasColumnType("int")
                        .HasColumnName("idPac");

                    b.Property<string>("IdUsuario")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idUsuario");

                    b.HasKey("NroAtencion");

                    b.HasIndex("IdPac");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Atencion", (string)null);
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.DetalleOrden", b =>
                {
                    b.Property<int>("IdDetOrden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idDetOrden");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetOrden"), 1L, 1);

                    b.Property<int>("CodExa")
                        .HasColumnType("int")
                        .HasColumnName("codExa");

                    b.Property<int>("NroOrden")
                        .HasColumnType("int")
                        .HasColumnName("nroOrden");

                    b.HasKey("IdDetOrden");

                    b.HasIndex("CodExa");

                    b.HasIndex("NroOrden");

                    b.ToTable("detalleOrden", (string)null);
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.DetalleRecetum", b =>
                {
                    b.Property<int>("IdDetReceta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idDetReceta");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetReceta"), 1L, 1);

                    b.Property<int>("CodFar")
                        .HasColumnType("int")
                        .HasColumnName("codFar");

                    b.Property<string>("Dosis")
                        .HasColumnType("text")
                        .HasColumnName("dosis");

                    b.Property<int>("NroReceta")
                        .HasColumnType("int")
                        .HasColumnName("nroReceta");

                    b.HasKey("IdDetReceta");

                    b.HasIndex("CodFar");

                    b.HasIndex("NroReceta");

                    b.ToTable("detalleReceta", (string)null);
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Especialidad", b =>
                {
                    b.Property<int>("CodEsp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codEsp");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodEsp"), 1L, 1);

                    b.Property<string>("NomEsp")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nomEsp");

                    b.HasKey("CodEsp");

                    b.ToTable("Especialidad", (string)null);
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.EspecialidadMedico", b =>
                {
                    b.Property<int>("CodEsp")
                        .HasColumnType("int")
                        .HasColumnName("codEsp");

                    b.Property<string>("IdUsuario")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idUsuario");

                    b.HasIndex("CodEsp");

                    b.HasIndex("IdUsuario");

                    b.ToTable("EspecialidadMedico", (string)null);
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Examan", b =>
                {
                    b.Property<int>("CodExa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codExa");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodExa"), 1L, 1);

                    b.Property<int>("CodTipo")
                        .HasColumnType("int")
                        .HasColumnName("codTipo");

                    b.Property<string>("NomExa")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nomExa");

                    b.HasKey("CodExa");

                    b.HasIndex("CodTipo");

                    b.ToTable("Examen");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Farmaco", b =>
                {
                    b.Property<int>("CodFar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codFar");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodFar"), 1L, 1);

                    b.Property<int>("CodPresentacion")
                        .HasColumnType("int")
                        .HasColumnName("codPresentacion");

                    b.Property<int>("CodUom")
                        .HasColumnType("int")
                        .HasColumnName("codUOM");

                    b.Property<double>("Concentracion")
                        .HasColumnType("float")
                        .HasColumnName("concentracion");

                    b.Property<string>("NomFar")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nomFar");

                    b.HasKey("CodFar");

                    b.HasIndex("CodPresentacion");

                    b.HasIndex("CodUom");

                    b.ToTable("Farmaco", (string)null);
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Orden", b =>
                {
                    b.Property<int>("NroOrden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("nroOrden");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NroOrden"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("fecha");

                    b.Property<int>("IdPac")
                        .HasColumnType("int")
                        .HasColumnName("idPac");

                    b.Property<string>("IdUsuario")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idUsuario");

                    b.Property<int>("NroAtencion")
                        .HasColumnType("int")
                        .HasColumnName("nroAtencion");

                    b.HasKey("NroOrden");

                    b.HasIndex("IdPac");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("NroAtencion");

                    b.ToTable("Orden", (string)null);
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Paciente", b =>
                {
                    b.Property<int>("IdPac")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idPac");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPac"), 1L, 1);

                    b.Property<string>("ApMaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApPaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodSexo")
                        .HasColumnType("int")
                        .HasColumnName("codSexo");

                    b.Property<int>("EdadPac")
                        .HasColumnType("int")
                        .HasColumnName("edadPac");

                    b.Property<DateTime>("FecNacPac")
                        .HasColumnType("date")
                        .HasColumnName("fecNacPac");

                    b.Property<string>("NomPac")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nomPac");

                    b.Property<int>("RutPac")
                        .HasColumnType("int")
                        .HasColumnName("rutPac");

                    b.HasKey("IdPac");

                    b.HasIndex("CodSexo");

                    b.ToTable("Paciente", (string)null);
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.PresentacionFarmaco", b =>
                {
                    b.Property<int>("CodPresentacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codPresentacion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodPresentacion"), 1L, 1);

                    b.Property<string>("NomPresentacion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nomPresentacion");

                    b.HasKey("CodPresentacion");

                    b.ToTable("PresentacionFarmaco", (string)null);
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Recetum", b =>
                {
                    b.Property<int>("NroReceta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("nroReceta");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NroReceta"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("fecha");

                    b.Property<int>("IdPac")
                        .HasColumnType("int")
                        .HasColumnName("idPac");

                    b.Property<string>("IdUsuario")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idUsuario");

                    b.Property<int>("NroAtencion")
                        .HasColumnType("int")
                        .HasColumnName("nroAtencion");

                    b.HasKey("NroReceta");

                    b.HasIndex("IdPac");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("NroAtencion");

                    b.ToTable("Receta");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Sexo", b =>
                {
                    b.Property<int>("CodSexo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codSexo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodSexo"), 1L, 1);

                    b.Property<string>("NomSexo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nomSexo");

                    b.HasKey("CodSexo");

                    b.ToTable("Sexo", (string)null);
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.TipoExaman", b =>
                {
                    b.Property<int>("CodTipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codTipo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodTipo"), 1L, 1);

                    b.Property<string>("NomTipo")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nomTipo");

                    b.HasKey("CodTipo");

                    b.ToTable("TipoExamen");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.UnidadDeMedidum", b =>
                {
                    b.Property<int>("CodUom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codUOM");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodUom"), 1L, 1);

                    b.Property<string>("NomUom")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nomUOM");

                    b.HasKey("CodUom");

                    b.ToTable("UnidadDeMedida");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.ApplicationUser", b =>
                {
                    b.HasOne("FCE_KillCoronaVirus.Models.Sexo", "CodSexoNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("CodSexo")
                        .IsRequired()
                        .HasConstraintName("FK_Usuarios_Sexo");

                    b.Navigation("CodSexoNavigation");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Atencion", b =>
                {
                    b.HasOne("FCE_KillCoronaVirus.Models.Paciente", "IdPacNavigation")
                        .WithMany("Atencions")
                        .HasForeignKey("IdPac")
                        .IsRequired()
                        .HasConstraintName("FK_Atencion_Paciente");

                    b.HasOne("FCE_KillCoronaVirus.Models.ApplicationUser", "IdUsuarioNavigation")
                        .WithMany("Atencions")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_Atencion_Usuarios");

                    b.Navigation("IdPacNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.DetalleOrden", b =>
                {
                    b.HasOne("FCE_KillCoronaVirus.Models.Examan", "CodExaNavigation")
                        .WithMany("DetalleOrdens")
                        .HasForeignKey("CodExa")
                        .IsRequired()
                        .HasConstraintName("FK_detalleOrden_Examen");

                    b.HasOne("FCE_KillCoronaVirus.Models.Orden", "NroOrdenNavigation")
                        .WithMany("DetalleOrdens")
                        .HasForeignKey("NroOrden")
                        .IsRequired()
                        .HasConstraintName("FK_detalleOrden_Orden");

                    b.Navigation("CodExaNavigation");

                    b.Navigation("NroOrdenNavigation");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.DetalleRecetum", b =>
                {
                    b.HasOne("FCE_KillCoronaVirus.Models.Farmaco", "CodFarNavigation")
                        .WithMany("DetalleReceta")
                        .HasForeignKey("CodFar")
                        .IsRequired()
                        .HasConstraintName("FK_detalleReceta_Farmaco");

                    b.HasOne("FCE_KillCoronaVirus.Models.Recetum", "NroRecetaNavigation")
                        .WithMany("DetalleReceta")
                        .HasForeignKey("NroReceta")
                        .IsRequired()
                        .HasConstraintName("FK_detalleReceta_Receta");

                    b.Navigation("CodFarNavigation");

                    b.Navigation("NroRecetaNavigation");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.EspecialidadMedico", b =>
                {
                    b.HasOne("FCE_KillCoronaVirus.Models.Especialidad", "CodEspNavigation")
                        .WithMany()
                        .HasForeignKey("CodEsp")
                        .IsRequired()
                        .HasConstraintName("FK_EspecialidadMedico_Especilidad");

                    b.HasOne("FCE_KillCoronaVirus.Models.ApplicationUser", "IdUsuarioNavigation")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_EspecialidadMedico_Usuarios");

                    b.Navigation("CodEspNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Examan", b =>
                {
                    b.HasOne("FCE_KillCoronaVirus.Models.TipoExaman", "CodTipoNavigation")
                        .WithMany("Examen")
                        .HasForeignKey("CodTipo")
                        .IsRequired()
                        .HasConstraintName("FK_Examen_TipoExamen");

                    b.Navigation("CodTipoNavigation");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Farmaco", b =>
                {
                    b.HasOne("FCE_KillCoronaVirus.Models.PresentacionFarmaco", "CodPresentacionNavigation")
                        .WithMany("Farmacos")
                        .HasForeignKey("CodPresentacion")
                        .IsRequired()
                        .HasConstraintName("FK_Farmaco_PresentacionFarmaco");

                    b.HasOne("FCE_KillCoronaVirus.Models.UnidadDeMedidum", "CodUomNavigation")
                        .WithMany("Farmacos")
                        .HasForeignKey("CodUom")
                        .IsRequired()
                        .HasConstraintName("FK_Farmaco_UnidadDeMedida");

                    b.Navigation("CodPresentacionNavigation");

                    b.Navigation("CodUomNavigation");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Orden", b =>
                {
                    b.HasOne("FCE_KillCoronaVirus.Models.Paciente", "IdPacNavigation")
                        .WithMany("Ordens")
                        .HasForeignKey("IdPac")
                        .IsRequired()
                        .HasConstraintName("FK_Orden_Paciente");

                    b.HasOne("FCE_KillCoronaVirus.Models.ApplicationUser", "IdUsuarioNavigation")
                        .WithMany("Ordens")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_Orden_Usuarios");

                    b.HasOne("FCE_KillCoronaVirus.Models.Atencion", "NroAtencionNavigation")
                        .WithMany("Ordens")
                        .HasForeignKey("NroAtencion")
                        .IsRequired()
                        .HasConstraintName("FK_Orden_Atencion");

                    b.Navigation("IdPacNavigation");

                    b.Navigation("IdUsuarioNavigation");

                    b.Navigation("NroAtencionNavigation");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Paciente", b =>
                {
                    b.HasOne("FCE_KillCoronaVirus.Models.Sexo", "CodSexoNavigation")
                        .WithMany("Pacientes")
                        .HasForeignKey("CodSexo")
                        .IsRequired()
                        .HasConstraintName("FK_Paciente_Sexo");

                    b.Navigation("CodSexoNavigation");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Recetum", b =>
                {
                    b.HasOne("FCE_KillCoronaVirus.Models.Paciente", "IdPacNavigation")
                        .WithMany("Receta")
                        .HasForeignKey("IdPac")
                        .IsRequired()
                        .HasConstraintName("FK_Receta_Paciente");

                    b.HasOne("FCE_KillCoronaVirus.Models.ApplicationUser", "IdUsuarioNavigation")
                        .WithMany("Receta")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_Receta_Usuarios");

                    b.HasOne("FCE_KillCoronaVirus.Models.Atencion", "NroAtencionNavigation")
                        .WithMany("Receta")
                        .HasForeignKey("NroAtencion")
                        .IsRequired()
                        .HasConstraintName("FK_Receta_Atencion");

                    b.Navigation("IdPacNavigation");

                    b.Navigation("IdUsuarioNavigation");

                    b.Navigation("NroAtencionNavigation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FCE_KillCoronaVirus.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FCE_KillCoronaVirus.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FCE_KillCoronaVirus.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FCE_KillCoronaVirus.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.ApplicationUser", b =>
                {
                    b.Navigation("Atencions");

                    b.Navigation("Ordens");

                    b.Navigation("Receta");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Atencion", b =>
                {
                    b.Navigation("Ordens");

                    b.Navigation("Receta");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Examan", b =>
                {
                    b.Navigation("DetalleOrdens");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Farmaco", b =>
                {
                    b.Navigation("DetalleReceta");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Orden", b =>
                {
                    b.Navigation("DetalleOrdens");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Paciente", b =>
                {
                    b.Navigation("Atencions");

                    b.Navigation("Ordens");

                    b.Navigation("Receta");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.PresentacionFarmaco", b =>
                {
                    b.Navigation("Farmacos");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Recetum", b =>
                {
                    b.Navigation("DetalleReceta");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.Sexo", b =>
                {
                    b.Navigation("Pacientes");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.TipoExaman", b =>
                {
                    b.Navigation("Examen");
                });

            modelBuilder.Entity("FCE_KillCoronaVirus.Models.UnidadDeMedidum", b =>
                {
                    b.Navigation("Farmacos");
                });
#pragma warning restore 612, 618
        }
    }
}
