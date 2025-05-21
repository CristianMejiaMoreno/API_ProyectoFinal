using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class PreRequisitoCursoDTO
    {
        [Key, Column(Order = 0)]
        public int CursoId { get; set; }

        [Key, Column(Order = 1)]
        public int PreRequisitoId { get; set; }

        public DateTime FechaDefinicion { get; set; }

        [ForeignKey(nameof(CursoId))]
        public virtual CursoDTO Curso { get; set; }

        [ForeignKey(nameof(PreRequisitoId))]
        public virtual CursoDTO PreRequisito { get; set; }
    }
}
