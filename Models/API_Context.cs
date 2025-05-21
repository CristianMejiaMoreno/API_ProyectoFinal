using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API_ProyectoFinal.Models
{
    public class API_Context : DbContext
    {
        public API_Context(DbContextOptions<API_Context> options)
            : base(options) { }
        //Migracion 1
        public DbSet<UsuarioDTO> Usuarios { get; set; }
        public DbSet<RolDTO> Roles { get; set; }
        public DbSet<UsuarioRolDTO> UsuarioRoles { get; set; }

        //Migracion 2
        public DbSet<ModalidadDTO> Modalidades { get; set; }
        public DbSet<NivelDificultadDTO> NivelDificultad { get; set; }
        public DbSet<CategoriaCursoDTO> CategoriaCursos { get; set; }//Intermedia

        //Migracion 3 
        public DbSet<CursoDTO> Cursos { get; set; }
        public DbSet<ProgramaDTO> Programa { get; set; }
        public DbSet<PreRequisitoCursoDTO> PreRequisito { get; set; } //Intermedia
        public DbSet<CursoProgramaDTO> CursoPrograma { get; set; }//Intermedia

        //Migracion 4
        public DbSet<OfertaCursoDTO> OfertaCurso { get; set; }
        public DbSet<CiudadDTO> Ciudad { get; set; }
        public DbSet<SedeDTO> Sede { get; set; }
        public DbSet<SalonDTO> Salon { get; set; }

        //Migracion 5
        public DbSet<HorarioDTO> Horario { get; set; }
        public DbSet<CursoHorarioDTO> CursoHorario {get; set; }//intermedia
        public DbSet<InscripcionDTO> Inscripcion { get; set; }
        public DbSet<PagoDTO> Pago { get; set; }

        //Migracion 6
        public DbSet<FacturaDTO> Factura { get; set; }
        public DbSet<EvaluacionDTO> Evaluacion { get; set; }
        public DbSet<CalificacionDTO> Calificacion { get; set; }
        public DbSet<CategoriaEquipoDTO> CategoriaEquipo { get; set; }

        //Migracion 7
        public DbSet<ProveedorDTO> Provedor { get; set; }
        public DbSet<EquipoDTO> Equipo { get; set; }
        public DbSet<OrdenCompraDTO> OrdenCompra { get; set; }
        public DbSet<ItemOrdenDTO> ItemOrder { get; set; }//Intermedia

        //Migracion 8
        public DbSet<TipoCertificadoDTO> TipoCertificado { get; set; }
        public DbSet<CertificadoDTO> Certificado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            // Si necesitas loguear en lugar de ignorar:
            // .Log(RelationalEventId.PendingModelChangesWarning);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Migración 1: Usuario, Rol, UsuarioRol
            modelBuilder.Entity<UsuarioDTO>().ToTable("Usuario");
            modelBuilder.Entity<RolDTO>().ToTable("Rol");

            modelBuilder.Entity<UsuarioRolDTO>()
                .ToTable("UsuarioRol")
                .HasKey(ur => new { ur.UsuarioId, ur.RolId });

            modelBuilder.Entity<UsuarioRolDTO>()
                .HasOne(ur => ur.Usuario)
                .WithMany(u => u.UsuarioRoles)
                .HasForeignKey(ur => ur.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioRolDTO>()
                .HasOne(ur => ur.Rol)
                .WithMany(r => r.UsuarioRoles)
                .HasForeignKey(ur => ur.RolId)
                .OnDelete(DeleteBehavior.Cascade);

            // Migración 2: Modalidad, NivelDificultad, CategoriaCurso
            modelBuilder.Entity<ModalidadDTO>().ToTable("Modalidad");
            modelBuilder.Entity<NivelDificultadDTO>().ToTable("NivelDificultad");
            modelBuilder.Entity<CategoriaCursoDTO>().ToTable("CategoriaCurso");

            // Migración 3: Curso, Programa, PreRequisitoCurso, CursoPrograma
            modelBuilder.Entity<CursoDTO>().ToTable("Curso");
            modelBuilder.Entity<ProgramaDTO>().ToTable("Programa");

            modelBuilder.Entity<PreRequisitoCursoDTO>()
                .ToTable("PreRequisitoCurso")
                .HasKey(pr => new { pr.CursoId, pr.PreRequisitoId });

            modelBuilder.Entity<PreRequisitoCursoDTO>()
                .HasOne(pr => pr.Curso)
                .WithMany(c => c.PreRequisitos)
                .HasForeignKey(pr => pr.CursoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PreRequisitoCursoDTO>()
                .HasOne(pr => pr.PreRequisito)
                .WithMany(c => c.EsPrerequisitoDe)
                .HasForeignKey(pr => pr.PreRequisitoId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<CursoProgramaDTO>()
                .ToTable("CursoPrograma")
                .HasKey(cp => new { cp.CursoId, cp.ProgramaId });

            modelBuilder.Entity<CursoProgramaDTO>()
                .HasOne(cp => cp.Curso)
                .WithMany(c => c.CursoProgramas)
                .HasForeignKey(cp => cp.CursoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CursoProgramaDTO>()
                .HasOne(cp => cp.Programa)
                .WithMany(p => p.CursoProgramas)
                .HasForeignKey(cp => cp.ProgramaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Migración 4: OfertaCurso, Ciudad, Sede, Salon
            modelBuilder.Entity<OfertaCursoDTO>().ToTable("OfertaCurso");
            modelBuilder.Entity<CiudadDTO>().ToTable("Ciudad");
            modelBuilder.Entity<SedeDTO>().ToTable("Sede");
            modelBuilder.Entity<SalonDTO>().ToTable("Salon");

            modelBuilder.Entity<SedeDTO>()
                .HasOne(s => s.Ciudad)
                .WithMany(c => c.Sedes)
                .HasForeignKey(s => s.CiudadId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SalonDTO>()
                .HasOne(s => s.Sede)
                .WithMany(se => se.Salones)
                .HasForeignKey(s => s.SedeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Mantener cascada sólo en Curso → OfertaCurso
            modelBuilder.Entity<OfertaCursoDTO>()
                .HasOne(o => o.Curso)
                .WithMany(c => c.Ofertas)
                .HasForeignKey(o => o.CursoId)
                .OnDelete(DeleteBehavior.Cascade);

            // NUEVA RELACIÓN AÑADIDA AQUÍ
            modelBuilder.Entity<OfertaCursoDTO>()
                .HasOne(o => o.Sede)
                .WithMany(s => s.OfertasCurso)
                .HasForeignKey(o => o.SedeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OfertaCursoDTO>()
                .HasOne(o => o.Salon)
                .WithMany(s => s.Ofertas)
                .HasForeignKey(o => o.SalonId)
                .OnDelete(DeleteBehavior.Restrict);

            // Migración 5: Horario, CursoHorario, Inscripcion, Pago
            modelBuilder.Entity<HorarioDTO>().ToTable("Horario");

            modelBuilder.Entity<CursoHorarioDTO>()
            .ToTable("CursoHorario")
            .HasKey(ch => new { ch.OfertaID, ch.HorarioID, ch.SalonID });

            modelBuilder.Entity<CursoHorarioDTO>()
                .HasOne(ch => ch.OfertaCurso)
                .WithMany(o => o.CursoHorarios)
                .HasForeignKey(ch => ch.OfertaID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CursoHorarioDTO>()
                .HasOne(ch => ch.Horario)
                .WithMany(h => h.CursoHorarios)
                .HasForeignKey(ch => ch.HorarioID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CursoHorarioDTO>()
                .HasOne(ch => ch.Salon)
                .WithMany(s => s.CursoHorarios)
                .HasForeignKey(ch => ch.SalonID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InscripcionDTO>().ToTable("Inscripcion");

            modelBuilder.Entity<InscripcionDTO>()
                .HasOne(i => i.Estudiante)
                .WithMany(u => u.Inscripciones)
                .HasForeignKey(i => i.EstudianteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InscripcionDTO>()
                .HasOne(i => i.OfertaCurso)
                .WithMany(o => o.Inscripciones)
                .HasForeignKey(i => i.OfertaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PagoDTO>().ToTable("Pago");

            modelBuilder.Entity<PagoDTO>()
                .HasOne(p => p.Inscripcion)
                .WithMany(i => i.Pagos)
                .HasForeignKey(p => p.InscripcionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Migración 6: Factura, Evaluacion, Calificacion, CategoriaEquipo
            modelBuilder.Entity<FacturaDTO>().ToTable("Factura");

            modelBuilder.Entity<FacturaDTO>()
                .HasOne(f => f.Pago)
                .WithMany(p => p.Facturas)
                .HasForeignKey(f => f.PagoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EvaluacionDTO>().ToTable("Evaluacion");

            modelBuilder.Entity<EvaluacionDTO>()
                .HasOne(e => e.Curso)
                .WithMany(c => c.Evaluaciones)
                .HasForeignKey(e => e.CursoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EvaluacionDTO>()
                .HasOne(e => e.OfertaCurso)
                .WithMany(o => o.Evaluaciones)
                .HasForeignKey(e => e.OfertaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CalificacionDTO>().ToTable("Calificacion");

            modelBuilder.Entity<CalificacionDTO>()
                .HasOne(c => c.Evaluacion)
                .WithMany(e => e.Calificaciones)
                .HasForeignKey(c => c.EvaluacionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CalificacionDTO>()
                .HasOne(c => c.Estudiante)
                .WithMany(u => u.Calificaciones)
                .HasForeignKey(c => c.EstudianteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CategoriaEquipoDTO>().ToTable("CategoriaEquipo");

            // Migración 7: Proveedor, Equipo, OrdenCompra, ItemOrden
            modelBuilder.Entity<ProveedorDTO>().ToTable("Proveedor");

            modelBuilder.Entity<EquipoDTO>().ToTable("Equipo");

            modelBuilder.Entity<EquipoDTO>()
                .HasOne(e => e.CategoriaEquipo)
                .WithMany(c => c.Equipos)
                .HasForeignKey(e => e.CategoriaEquipoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrdenCompraDTO>().ToTable("OrdenCompra");

            modelBuilder.Entity<OrdenCompraDTO>()
                .HasOne(o => o.Proveedor)
                .WithMany(p => p.OrdenesCompra)
                .HasForeignKey(o => o.ProveedorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemOrdenDTO>()
                .ToTable("ItemOrden")
                .HasKey(io => new { io.OrdenId, io.EquipoId });

            modelBuilder.Entity<ItemOrdenDTO>()
                .HasOne(io => io.OrdenCompra)
                .WithMany(o => o.ItemsOrden)
                .HasForeignKey(io => io.OrdenId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemOrdenDTO>()
                .HasOne(io => io.Equipo)
                .WithMany(e => e.ItemsOrden)
                .HasForeignKey(io => io.EquipoId)
                .OnDelete(DeleteBehavior.Cascade);


            // Migración 8: TipoCertificado, Certificado
            modelBuilder.Entity<TipoCertificadoDTO>().ToTable("TipoCertificado");

            modelBuilder.Entity<CertificadoDTO>().ToTable("Certificado");

            modelBuilder.Entity<CertificadoDTO>()
                .HasOne(c => c.TipoCertificado)
                .WithMany(t => t.Certificados)
                .HasForeignKey(c => c.TipoCertID)
                .OnDelete(DeleteBehavior.Cascade);

            // CAMBIO AQUÍ: De Cascade a Restrict
            modelBuilder.Entity<CertificadoDTO>()
                .HasOne(c => c.Estudiante)
                .WithMany(u => u.Certificados)
                .HasForeignKey(c => c.EstudianteId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
