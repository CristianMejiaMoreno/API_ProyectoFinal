using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class CategoriaCursoDTO
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }
        public int OrdenVisual {  get; set; }
        public bool Activo { get; set; }
        public virtual ICollection<CursoDTO> Cursos { get; set; } = new List<CursoDTO>();

    }
}
