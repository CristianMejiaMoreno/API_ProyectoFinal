using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class ProveedorDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string ContactoTelefono { get; set; }
        public string ContactoEmail { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<OrdenCompraDTO> OrdenesCompra { get; set; } = new List<OrdenCompraDTO>();
    }
}
