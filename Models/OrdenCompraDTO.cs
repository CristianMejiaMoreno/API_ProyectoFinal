using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class OrdenCompraDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrdenId { get; set; }
        public DateTime FechaOrden { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal Total { get; set; }

        public int ProveedorId { get; set; }
        [ForeignKey("ProveedorId")]
        public virtual ProveedorDTO Proveedor { get; set; }
        public virtual ICollection<ItemOrdenDTO> ItemsOrden { get; set; } = new List<ItemOrdenDTO>();
    }
}
