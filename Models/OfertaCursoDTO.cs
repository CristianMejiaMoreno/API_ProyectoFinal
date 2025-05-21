using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class OfertaCursoDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfertaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CupoMaximo { get; set; }
        public string Estado { get; set; }

        public int CursoId { get; set; }
        [ForeignKey("CursoId")]
        public virtual CursoDTO Curso { get; set; }

        public int InstructorId { get; set; }
        [ForeignKey("InstructorId")]
        public virtual UsuarioDTO Instructor { get; set; }

        public int SedeId { get; set; }
        [ForeignKey("SedeId")]
        public virtual SedeDTO Sede { get; set; }

        public int SalonId { get; set; }
        [ForeignKey(nameof(SalonId))]
        public virtual SalonDTO Salon { get; set; }

        public virtual ICollection<EvaluacionDTO> Evaluaciones { get; set; } = new List<EvaluacionDTO>();
        public virtual ICollection<CursoHorarioDTO> CursoHorarios { get; set; } = new List<CursoHorarioDTO>();
        public virtual ICollection<InscripcionDTO> Inscripciones { get; set; } = new List<InscripcionDTO>();

    }
}
