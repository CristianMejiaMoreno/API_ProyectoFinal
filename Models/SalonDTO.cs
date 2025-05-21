using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class SalonDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalonId { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }

        public int SedeId { get; set; }
        [ForeignKey("SedeId")]
        public virtual SedeDTO Sede { get; set; }
        public virtual ICollection<CursoHorarioDTO> CursoHorarios { get; set; } = new List<CursoHorarioDTO>();
        public virtual ICollection<OfertaCursoDTO> Ofertas { get; set; } = new List<OfertaCursoDTO>();


    }
}
