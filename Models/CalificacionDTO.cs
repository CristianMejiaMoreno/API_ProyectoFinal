using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class CalificacionDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CalificacionID { get; set; }
        public decimal Nota { get; set; }
        public string Observaciones { get; set; }


        public int EvaluacionId { get; set; }
        [ForeignKey("EvaluacionId")]
        public virtual EvaluacionDTO Evaluacion { get; set; }

        public int EstudianteId { get; set; }
        [ForeignKey("EstudianteId")]
        public virtual UsuarioDTO Estudiante { get; set; }
    }
}
