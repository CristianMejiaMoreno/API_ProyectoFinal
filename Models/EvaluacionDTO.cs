using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class EvaluacionDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EvaluacionId { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public int PesoPorcentaje { get; set; }
        public string Tipo { get; set; }
        public int CursoId { get; set; }
        [ForeignKey("CursoId")]
        public virtual CursoDTO Curso { get; set; }
        public int OfertaId { get; set; }
        [ForeignKey("OfertaId")]
        public virtual OfertaCursoDTO OfertaCurso { get; set; }
        public virtual ICollection<CalificacionDTO> Calificaciones { get; set; } = new List<CalificacionDTO>();
    }
}

