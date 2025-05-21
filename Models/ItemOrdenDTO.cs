using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class ItemOrdenDTO
    {
        public int ItemOrdenId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }

        public int OrdenId { get; set; }
        [ForeignKey("OrdenId")]
        public virtual OrdenCompraDTO OrdenCompra { get; set; }

        public int EquipoId { get; set; }
        [ForeignKey("EquipoId")]
        public virtual EquipoDTO Equipo { get; set; }
    }
}
