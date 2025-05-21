using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class CiudadDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CiudadId { get; set; }
        public string Nombre { get; set; }
        public string ProvinciaEstado { get; set; }
        public string Pais { get; set; }
        public string CodigoPostal { get; set; }

        public virtual ICollection<SedeDTO> Sedes { get; set; } = new List<SedeDTO>();

    }
}
