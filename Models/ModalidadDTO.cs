using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class ModalidadDTO
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int ModalidadId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion {  get; set; }
        public bool Activo { get; set; }
        public virtual ICollection<CursoDTO> Cursos { get; set; } = new List<CursoDTO>();

    }
}
