using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_ProyectoFinal.Models
{
    public class SedeDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SedeId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string TelefonoContacto { get; set; }
        public int CiudadId { get; set; }
        [ForeignKey("CiudadId")]
        public virtual CiudadDTO Ciudad { get; set; }
        public virtual ICollection<SalonDTO> Salones { get; set; } = new List<SalonDTO>();
        public virtual ICollection<OfertaCursoDTO> Ofertas { get; set; } = new List<OfertaCursoDTO>();
        public virtual ICollection<OfertaCursoDTO> OfertasCurso { get; set; } = new List<OfertaCursoDTO>();

    }
}
