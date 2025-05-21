using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class CursoProgramaDTO
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Curso))]
        public int CursoId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Programa))]
        public int ProgramaId { get; set; }

        public DateTime FechaDefinicion { get; set; }

        public virtual CursoDTO Curso { get; set; }
        public virtual ProgramaDTO Programa { get; set; }
    }
}
