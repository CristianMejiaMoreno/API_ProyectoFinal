using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class CursoHorarioDTO
    {
        [Key, Column(Order = 0)]
        public int OfertaID { get; set; }

        [Key, Column(Order = 1)]
        public int HorarioID { get; set; }

        [Key, Column(Order = 2)]
        public int SalonID { get; set; }

        public DateTime FechaRegistro { get; set; }

        [ForeignKey(nameof(OfertaID))]
        public virtual OfertaCursoDTO OfertaCurso { get; set; }

        [ForeignKey(nameof(HorarioID))]
        public virtual HorarioDTO Horario { get; set; }

        [ForeignKey(nameof(SalonID))]
        public virtual SalonDTO Salon { get; set; }

        public virtual CursoDTO Curso { get; set; }
    }
}
