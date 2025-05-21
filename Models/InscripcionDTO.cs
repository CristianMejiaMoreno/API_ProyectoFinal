using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class InscripcionDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InscripcionId { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string Estado { get; set; }

        public int EstudianteId { get; set; }
        [ForeignKey("EstudianteId")]
        public virtual UsuarioDTO Estudiante { get; set; }
        public int OfertaId { get; set; }
        [ForeignKey("OfertaId")]
        public virtual OfertaCursoDTO OfertaCurso { get; set; }

        public virtual ICollection<PagoDTO> Pagos { get; set; } = new List<PagoDTO>();

    }
}
