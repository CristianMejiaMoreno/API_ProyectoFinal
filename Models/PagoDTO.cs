
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class PagoDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PagoId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string EstadoPago { get; set; }

        public int InscripcionId { get; set; }
        [ForeignKey("InscripcionId")]
        public virtual InscripcionDTO Inscripcion { get; set; }

        public int MetodoId { get; set; }

        public virtual ICollection<FacturaDTO> Facturas { get; set; } = new List<FacturaDTO>();
        public virtual FacturaDTO Factura { get; set; }
    }
}
