using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class EquipoDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CantidadStock { get; set; }

        public int CategoriaEquipoId { get; set; }
        [ForeignKey("CategoriaEquipoId")]
        public virtual CategoriaEquipoDTO CategoriaEquipo { get; set; }
        public virtual ICollection<ItemOrdenDTO> ItemsOrden { get; set; } = new List<ItemOrdenDTO>();
    }
}
