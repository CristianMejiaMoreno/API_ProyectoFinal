using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_ProyectoFinal.Models
{
    public class RolDTO
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int RolId { get; set; }

        public string NombreRol {  get; set; }

        [JsonIgnore]
        public virtual ICollection<UsuarioDTO>? Usuarios { get; set; } = new List<UsuarioDTO>();
        [JsonIgnore]
        public virtual ICollection<UsuarioRolDTO> UsuarioRoles { get; }
            = new List<UsuarioRolDTO>();

    }
}
