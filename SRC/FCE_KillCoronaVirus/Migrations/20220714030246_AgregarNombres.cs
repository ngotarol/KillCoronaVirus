using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCE_KillCoronaVirus.Migrations
{
    public partial class AgregarNombres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especilidad",
                columns: table => new
                {
                    codEsp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomEsp = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especilidad", x => x.codEsp);
                });

            migrationBuilder.CreateTable(
                name: "PresentacionFarmaco",
                columns: table => new
                {
                    codPresentacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomPresentacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentacionFarmaco", x => x.codPresentacion);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    codRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomRol = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.codRol);
                });

            migrationBuilder.CreateTable(
                name: "Sexo",
                columns: table => new
                {
                    codSexo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomSexo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.codSexo);
                });

            migrationBuilder.CreateTable(
                name: "TipoExamen",
                columns: table => new
                {
                    codTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomTipo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoExamen", x => x.codTipo);
                });

            migrationBuilder.CreateTable(
                name: "UnidadDeMedida",
                columns: table => new
                {
                    codUOM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomUOM = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadDeMedida", x => x.codUOM);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    idPac = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rutPac = table.Column<int>(type: "int", nullable: false),
                    nomPac = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ApPaterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApMaterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecNacPac = table.Column<DateTime>(type: "date", nullable: false),
                    edadPac = table.Column<int>(type: "int", nullable: false),
                    codSexo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.idPac);
                    table.ForeignKey(
                        name: "FK_Paciente_Sexo",
                        column: x => x.codSexo,
                        principalTable: "Sexo",
                        principalColumn: "codSexo");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rutUsuario = table.Column<int>(type: "int", nullable: false),
                    nomUsuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    codRol = table.Column<int>(type: "int", nullable: false),
                    codSexo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Rol",
                        column: x => x.codRol,
                        principalTable: "Rol",
                        principalColumn: "codRol");
                    table.ForeignKey(
                        name: "FK_Usuarios_Sexo",
                        column: x => x.codSexo,
                        principalTable: "Sexo",
                        principalColumn: "codSexo");
                });

            migrationBuilder.CreateTable(
                name: "Examen",
                columns: table => new
                {
                    codExa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomExa = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    codTipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examen", x => x.codExa);
                    table.ForeignKey(
                        name: "FK_Examen_TipoExamen",
                        column: x => x.codTipo,
                        principalTable: "TipoExamen",
                        principalColumn: "codTipo");
                });

            migrationBuilder.CreateTable(
                name: "Farmaco",
                columns: table => new
                {
                    codFar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomFar = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    concentracion = table.Column<double>(type: "float", nullable: false),
                    codUOM = table.Column<int>(type: "int", nullable: false),
                    codPresentacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmaco", x => x.codFar);
                    table.ForeignKey(
                        name: "FK_Farmaco_PresentacionFarmaco",
                        column: x => x.codPresentacion,
                        principalTable: "PresentacionFarmaco",
                        principalColumn: "codPresentacion");
                    table.ForeignKey(
                        name: "FK_Farmaco_UnidadDeMedida",
                        column: x => x.codUOM,
                        principalTable: "UnidadDeMedida",
                        principalColumn: "codUOM");
                });

            migrationBuilder.CreateTable(
                name: "Atencion",
                columns: table => new
                {
                    nroAtencion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datAtencion = table.Column<string>(type: "text", nullable: true),
                    idPac = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    fecha_hora = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atencion", x => x.nroAtencion);
                    table.ForeignKey(
                        name: "FK_Atencion_Paciente",
                        column: x => x.idPac,
                        principalTable: "Paciente",
                        principalColumn: "idPac");
                    table.ForeignKey(
                        name: "FK_Atencion_Usuarios",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "EspecialidadMedico",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    codEsp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_EspecialidadMedico_Especilidad",
                        column: x => x.codEsp,
                        principalTable: "Especilidad",
                        principalColumn: "codEsp");
                    table.ForeignKey(
                        name: "FK_EspecialidadMedico_Usuarios",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    nroOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nroAtencion = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idPac = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.nroOrden);
                    table.ForeignKey(
                        name: "FK_Orden_Atencion",
                        column: x => x.nroAtencion,
                        principalTable: "Atencion",
                        principalColumn: "nroAtencion");
                    table.ForeignKey(
                        name: "FK_Orden_Paciente",
                        column: x => x.idPac,
                        principalTable: "Paciente",
                        principalColumn: "idPac");
                    table.ForeignKey(
                        name: "FK_Orden_Usuarios",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Receta",
                columns: table => new
                {
                    nroReceta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idPac = table.Column<int>(type: "int", nullable: false),
                    nroAtencion = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receta", x => x.nroReceta);
                    table.ForeignKey(
                        name: "FK_Receta_Atencion",
                        column: x => x.nroAtencion,
                        principalTable: "Atencion",
                        principalColumn: "nroAtencion");
                    table.ForeignKey(
                        name: "FK_Receta_Paciente",
                        column: x => x.idPac,
                        principalTable: "Paciente",
                        principalColumn: "idPac");
                    table.ForeignKey(
                        name: "FK_Receta_Usuarios",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "detalleOrden",
                columns: table => new
                {
                    idDetOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nroOrden = table.Column<int>(type: "int", nullable: false),
                    codExa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleOrden", x => x.idDetOrden);
                    table.ForeignKey(
                        name: "FK_detalleOrden_Examen",
                        column: x => x.codExa,
                        principalTable: "Examen",
                        principalColumn: "codExa");
                    table.ForeignKey(
                        name: "FK_detalleOrden_Orden",
                        column: x => x.nroOrden,
                        principalTable: "Orden",
                        principalColumn: "nroOrden");
                });

            migrationBuilder.CreateTable(
                name: "detalleReceta",
                columns: table => new
                {
                    idDetReceta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nroReceta = table.Column<int>(type: "int", nullable: false),
                    codFar = table.Column<int>(type: "int", nullable: false),
                    dosis = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleReceta", x => x.idDetReceta);
                    table.ForeignKey(
                        name: "FK_detalleReceta_Farmaco",
                        column: x => x.codFar,
                        principalTable: "Farmaco",
                        principalColumn: "codFar");
                    table.ForeignKey(
                        name: "FK_detalleReceta_Receta",
                        column: x => x.nroReceta,
                        principalTable: "Receta",
                        principalColumn: "nroReceta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atencion_idPac",
                table: "Atencion",
                column: "idPac");

            migrationBuilder.CreateIndex(
                name: "IX_Atencion_idUsuario",
                table: "Atencion",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_detalleOrden_codExa",
                table: "detalleOrden",
                column: "codExa");

            migrationBuilder.CreateIndex(
                name: "IX_detalleOrden_nroOrden",
                table: "detalleOrden",
                column: "nroOrden");

            migrationBuilder.CreateIndex(
                name: "IX_detalleReceta_codFar",
                table: "detalleReceta",
                column: "codFar");

            migrationBuilder.CreateIndex(
                name: "IX_detalleReceta_nroReceta",
                table: "detalleReceta",
                column: "nroReceta");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadMedico_codEsp",
                table: "EspecialidadMedico",
                column: "codEsp");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadMedico_idUsuario",
                table: "EspecialidadMedico",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Examen_codTipo",
                table: "Examen",
                column: "codTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Farmaco_codPresentacion",
                table: "Farmaco",
                column: "codPresentacion");

            migrationBuilder.CreateIndex(
                name: "IX_Farmaco_codUOM",
                table: "Farmaco",
                column: "codUOM");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_idPac",
                table: "Orden",
                column: "idPac");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_idUsuario",
                table: "Orden",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_nroAtencion",
                table: "Orden",
                column: "nroAtencion");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_codSexo",
                table: "Paciente",
                column: "codSexo");

            migrationBuilder.CreateIndex(
                name: "IX_Receta_idPac",
                table: "Receta",
                column: "idPac");

            migrationBuilder.CreateIndex(
                name: "IX_Receta_idUsuario",
                table: "Receta",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Receta_nroAtencion",
                table: "Receta",
                column: "nroAtencion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_codRol",
                table: "Usuarios",
                column: "codRol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_codSexo",
                table: "Usuarios",
                column: "codSexo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleOrden");

            migrationBuilder.DropTable(
                name: "detalleReceta");

            migrationBuilder.DropTable(
                name: "EspecialidadMedico");

            migrationBuilder.DropTable(
                name: "Examen");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Farmaco");

            migrationBuilder.DropTable(
                name: "Receta");

            migrationBuilder.DropTable(
                name: "Especilidad");

            migrationBuilder.DropTable(
                name: "TipoExamen");

            migrationBuilder.DropTable(
                name: "PresentacionFarmaco");

            migrationBuilder.DropTable(
                name: "UnidadDeMedida");

            migrationBuilder.DropTable(
                name: "Atencion");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Sexo");
        }
    }
}
