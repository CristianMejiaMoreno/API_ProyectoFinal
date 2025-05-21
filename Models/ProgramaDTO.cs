using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class ProgramaDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProgramaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<CursoProgramaDTO> CursosProgramas { get; set; } = new List<CursoProgramaDTO>();
        public virtual ICollection<CursoProgramaDTO> CursoProgramas { get; set; } = new List<CursoProgramaDTO>();

    }
}
