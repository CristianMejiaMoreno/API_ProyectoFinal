using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class HorarioDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HorarioID { get; set; }
        public List<string> DiasSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public virtual ICollection<CursoHorarioDTO> CursoHorarios { get; set; } = new List<CursoHorarioDTO>();

    }
}
