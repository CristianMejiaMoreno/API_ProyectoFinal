using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class CertificadoDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CertificadoId { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Codigo { get; set; }

        public int EstudianteId { get; set; }
        [ForeignKey("EstudianteId")]
        public virtual UsuarioDTO Estudiante { get; set; }

        public int OfertaID { get; set; }
        [ForeignKey("OfertaID")]
        public virtual OfertaCursoDTO OfertaCurso { get; set; }

        public int TipoCertID { get; set; }
        [ForeignKey("TipoCertID")]
        public virtual TipoCertificadoDTO TipoCertificado { get; set; }
    }
}
