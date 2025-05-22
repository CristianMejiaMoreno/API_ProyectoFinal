using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_ProyectoFinal.Models
{
    public class CursoDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CursoId { get; set; }
        public string CodigoCurso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int DuracionHoras { get; set; }
        public decimal Costo { get; set; }


        //Relacion categoria curso
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        [JsonIgnore]
        public virtual CategoriaCursoDTO CategoriaCurso { get; set; }

        //Relacion modalidad curso
        public int  ModalidadId { get ; set; }
        [ForeignKey("ModalidadId")]
        [JsonIgnore]
        public virtual ModalidadDTO Modalidad { get; set; }
        //Relacion nivel curso
        public int NivelId { get; set; }
        [ForeignKey("NivelId")]
        [JsonIgnore]
        public virtual NivelDificultadDTO NivelDificultad { get;set; }

        public virtual ICollection<PreRequisitoCursoDTO> PreRequisitos { get; set; } = new List<PreRequisitoCursoDTO>();
        public virtual ICollection<PreRequisitoCursoDTO> EsPrerequisitoDe { get; set; } = new List<PreRequisitoCursoDTO>();
        public virtual ICollection<CursoProgramaDTO> CursoProgramas { get; set; } = new List<CursoProgramaDTO>();
        public virtual ICollection<OfertaCursoDTO> Ofertas { get; set; } = new List<OfertaCursoDTO>();
        public virtual ICollection<EvaluacionDTO> Evaluaciones { get; set; } = new List<EvaluacionDTO>();

    }
}
