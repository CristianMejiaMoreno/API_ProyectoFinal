using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class NivelDificultadDTO
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int NivelId { get; set; }
        public string Nombre {  get; set; }
        public int Ordanilidad { get; set; }
        public virtual ICollection<CursoDTO> Cursos { get; set; } = new List<CursoDTO>();


    }
}
