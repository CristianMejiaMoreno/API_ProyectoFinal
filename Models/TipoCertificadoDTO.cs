using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class TipoCertificadoDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoCertId { get; set; }
        public string Descripcion { get; set; }


        public virtual ICollection<CertificadoDTO> Certificados { get; set; } = new List<CertificadoDTO>();
    }
}
