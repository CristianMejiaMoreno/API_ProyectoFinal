using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class BaseDatosCompleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Roles_RolId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRol_Roles_RolId",
                table: "UsuarioRol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Rol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "RolId");

            migrationBuilder.CreateTable(
                name: "CategoriaCurso",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenVisual = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaCurso", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaEquipo",
                columns: table => new
                {
                    CategoriaEquipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaEquipo", x => x.CategoriaEquipoId);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaEstado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.CiudadId);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    HorarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiasSemana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.HorarioID);
                });

            migrationBuilder.CreateTable(
                name: "Modalidad",
                columns: table => new
                {
                    ModalidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidad", x => x.ModalidadId);
                });

            migrationBuilder.CreateTable(
                name: "NivelDificultad",
                columns: table => new
                {
                    NivelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ordanilidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelDificultad", x => x.NivelId);
                });

            migrationBuilder.CreateTable(
                name: "Programa",
                columns: table => new
                {
                    ProgramaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programa", x => x.ProgramaId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactoTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactoEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "TipoCertificado",
                columns: table => new
                {
                    TipoCertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCertificado", x => x.TipoCertId);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    EquipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadStock = table.Column<int>(type: "int", nullable: false),
                    CategoriaEquipoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.EquipoId);
                    table.ForeignKey(
                        name: "FK_Equipo_CategoriaEquipo_CategoriaEquipoId",
                        column: x => x.CategoriaEquipoId,
                        principalTable: "CategoriaEquipo",
                        principalColumn: "CategoriaEquipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sede",
                columns: table => new
                {
                    SedeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sede", x => x.SedeId);
                    table.ForeignKey(
                        name: "FK_Sede_Ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudad",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuracionHoras = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    ModalidadId = table.Column<int>(type: "int", nullable: false),
                    NivelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.CursoId);
                    table.ForeignKey(
                        name: "FK_Curso_CategoriaCurso_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriaCurso",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curso_Modalidad_ModalidadId",
                        column: x => x.ModalidadId,
                        principalTable: "Modalidad",
                        principalColumn: "ModalidadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curso_NivelDificultad_NivelId",
                        column: x => x.NivelId,
                        principalTable: "NivelDificultad",
                        principalColumn: "NivelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenCompra",
                columns: table => new
                {
                    OrdenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenCompra", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_OrdenCompra_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    SalonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    SedeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salon", x => x.SalonId);
                    table.ForeignKey(
                        name: "FK_Salon_Sede_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sede",
                        principalColumn: "SedeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CursoPrograma",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    ProgramaId = table.Column<int>(type: "int", nullable: false),
                    FechaDefinicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProgramaDTOProgramaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoPrograma", x => new { x.CursoId, x.ProgramaId });
                    table.ForeignKey(
                        name: "FK_CursoPrograma_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoPrograma_Programa_ProgramaDTOProgramaId",
                        column: x => x.ProgramaDTOProgramaId,
                        principalTable: "Programa",
                        principalColumn: "ProgramaId");
                    table.ForeignKey(
                        name: "FK_CursoPrograma_Programa_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programa",
                        principalColumn: "ProgramaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreRequisitoCurso",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    PreRequisitoId = table.Column<int>(type: "int", nullable: false),
                    FechaDefinicion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreRequisitoCurso", x => new { x.CursoId, x.PreRequisitoId });
                    table.ForeignKey(
                        name: "FK_PreRequisitoCurso_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PreRequisitoCurso_Curso_PreRequisitoId",
                        column: x => x.PreRequisitoId,
                        principalTable: "Curso",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemOrden",
                columns: table => new
                {
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    ItemOrdenId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrden", x => new { x.OrdenId, x.EquipoId });
                    table.ForeignKey(
                        name: "FK_ItemOrden_Equipo_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipo",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOrden_OrdenCompra_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "OrdenCompra",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfertaCurso",
                columns: table => new
                {
                    OfertaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CupoMaximo = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    SedeId = table.Column<int>(type: "int", nullable: false),
                    SalonId = table.Column<int>(type: "int", nullable: false),
                    SedeDTOSedeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaCurso", x => x.OfertaId);
                    table.ForeignKey(
                        name: "FK_OfertaCurso_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfertaCurso_Salon_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salon",
                        principalColumn: "SalonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfertaCurso_Sede_SedeDTOSedeId",
                        column: x => x.SedeDTOSedeId,
                        principalTable: "Sede",
                        principalColumn: "SedeId");
                    table.ForeignKey(
                        name: "FK_OfertaCurso_Sede_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sede",
                        principalColumn: "SedeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfertaCurso_Usuario_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificado",
                columns: table => new
                {
                    CertificadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    OfertaID = table.Column<int>(type: "int", nullable: false),
                    TipoCertID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificado", x => x.CertificadoId);
                    table.ForeignKey(
                        name: "FK_Certificado_OfertaCurso_OfertaID",
                        column: x => x.OfertaID,
                        principalTable: "OfertaCurso",
                        principalColumn: "OfertaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificado_TipoCertificado_TipoCertID",
                        column: x => x.TipoCertID,
                        principalTable: "TipoCertificado",
                        principalColumn: "TipoCertId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificado_Usuario_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CursoHorario",
                columns: table => new
                {
                    OfertaID = table.Column<int>(type: "int", nullable: false),
                    HorarioID = table.Column<int>(type: "int", nullable: false),
                    SalonID = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoHorario", x => new { x.OfertaID, x.HorarioID, x.SalonID });
                    table.ForeignKey(
                        name: "FK_CursoHorario_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoHorario_Horario_HorarioID",
                        column: x => x.HorarioID,
                        principalTable: "Horario",
                        principalColumn: "HorarioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoHorario_OfertaCurso_OfertaID",
                        column: x => x.OfertaID,
                        principalTable: "OfertaCurso",
                        principalColumn: "OfertaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CursoHorario_Salon_SalonID",
                        column: x => x.SalonID,
                        principalTable: "Salon",
                        principalColumn: "SalonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluacion",
                columns: table => new
                {
                    EvaluacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PesoPorcentaje = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    OfertaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluacion", x => x.EvaluacionId);
                    table.ForeignKey(
                        name: "FK_Evaluacion_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluacion_OfertaCurso_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "OfertaCurso",
                        principalColumn: "OfertaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                columns: table => new
                {
                    InscripcionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    OfertaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => x.InscripcionId);
                    table.ForeignKey(
                        name: "FK_Inscripcion_OfertaCurso_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "OfertaCurso",
                        principalColumn: "OfertaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Usuario_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calificacion",
                columns: table => new
                {
                    CalificacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvaluacionId = table.Column<int>(type: "int", nullable: false),
                    EstudianteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificacion", x => x.CalificacionID);
                    table.ForeignKey(
                        name: "FK_Calificacion_Evaluacion_EvaluacionId",
                        column: x => x.EvaluacionId,
                        principalTable: "Evaluacion",
                        principalColumn: "EvaluacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calificacion_Usuario_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroFactura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PagoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.FacturaId);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstadoPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InscripcionId = table.Column<int>(type: "int", nullable: false),
                    MetodoId = table.Column<int>(type: "int", nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pago_Factura_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Factura",
                        principalColumn: "FacturaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pago_Inscripcion_InscripcionId",
                        column: x => x.InscripcionId,
                        principalTable: "Inscripcion",
                        principalColumn: "InscripcionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_EstudianteId",
                table: "Calificacion",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_EvaluacionId",
                table: "Calificacion",
                column: "EvaluacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificado_EstudianteId",
                table: "Certificado",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificado_OfertaID",
                table: "Certificado",
                column: "OfertaID");

            migrationBuilder.CreateIndex(
                name: "IX_Certificado_TipoCertID",
                table: "Certificado",
                column: "TipoCertID");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_CategoriaId",
                table: "Curso",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_ModalidadId",
                table: "Curso",
                column: "ModalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_NivelId",
                table: "Curso",
                column: "NivelId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoHorario_CursoId",
                table: "CursoHorario",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoHorario_HorarioID",
                table: "CursoHorario",
                column: "HorarioID");

            migrationBuilder.CreateIndex(
                name: "IX_CursoHorario_SalonID",
                table: "CursoHorario",
                column: "SalonID");

            migrationBuilder.CreateIndex(
                name: "IX_CursoPrograma_ProgramaDTOProgramaId",
                table: "CursoPrograma",
                column: "ProgramaDTOProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoPrograma_ProgramaId",
                table: "CursoPrograma",
                column: "ProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_CategoriaEquipoId",
                table: "Equipo",
                column: "CategoriaEquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_CursoId",
                table: "Evaluacion",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_OfertaId",
                table: "Evaluacion",
                column: "OfertaId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_PagoId",
                table: "Factura",
                column: "PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_EstudianteId",
                table: "Inscripcion",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_OfertaId",
                table: "Inscripcion",
                column: "OfertaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrden_EquipoId",
                table: "ItemOrden",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaCurso_CursoId",
                table: "OfertaCurso",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaCurso_InstructorId",
                table: "OfertaCurso",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaCurso_SalonId",
                table: "OfertaCurso",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaCurso_SedeDTOSedeId",
                table: "OfertaCurso",
                column: "SedeDTOSedeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaCurso_SedeId",
                table: "OfertaCurso",
                column: "SedeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompra_ProveedorId",
                table: "OrdenCompra",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_FacturaId",
                table: "Pago",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_InscripcionId",
                table: "Pago",
                column: "InscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_PreRequisitoCurso_PreRequisitoId",
                table: "PreRequisitoCurso",
                column: "PreRequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Salon_SedeId",
                table: "Salon",
                column: "SedeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sede_CiudadId",
                table: "Sede",
                column: "CiudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRol_Rol_RolId",
                table: "UsuarioRol",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Pago_PagoId",
                table: "Factura",
                column: "PagoId",
                principalTable: "Pago",
                principalColumn: "PagoId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRol_Rol_RolId",
                table: "UsuarioRol");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripcion_OfertaCurso_OfertaId",
                table: "Inscripcion");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Pago_PagoId",
                table: "Factura");

            migrationBuilder.DropTable(
                name: "Calificacion");

            migrationBuilder.DropTable(
                name: "Certificado");

            migrationBuilder.DropTable(
                name: "CursoHorario");

            migrationBuilder.DropTable(
                name: "CursoPrograma");

            migrationBuilder.DropTable(
                name: "ItemOrden");

            migrationBuilder.DropTable(
                name: "PreRequisitoCurso");

            migrationBuilder.DropTable(
                name: "Evaluacion");

            migrationBuilder.DropTable(
                name: "TipoCertificado");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Programa");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "OrdenCompra");

            migrationBuilder.DropTable(
                name: "CategoriaEquipo");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "OfertaCurso");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Salon");

            migrationBuilder.DropTable(
                name: "CategoriaCurso");

            migrationBuilder.DropTable(
                name: "Modalidad");

            migrationBuilder.DropTable(
                name: "NivelDificultad");

            migrationBuilder.DropTable(
                name: "Sede");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Inscripcion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Roles_RolId",
                table: "Usuario",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRol_Roles_RolId",
                table: "UsuarioRol",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
