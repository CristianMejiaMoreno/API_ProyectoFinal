using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProyectoFinal.Models
{
    public class RolDTO
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int RolId { get; set; }

        public int NombreRol {  get; set; }

        public virtual ICollection<UsuarioDTO> Usuarios { get; set; }

        public virtual ICollection<UsuarioRolDTO> UsuarioRoles { get; }
            = new List<UsuarioRolDTO>();



    }
}
