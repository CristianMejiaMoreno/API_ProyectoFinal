using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class FacturaDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacturaId { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal Total { get; set; }

        public int PagoId { get; set; }
        [ForeignKey("PagoId")]
        public virtual PagoDTO Pago { get; set; }

    }
}
