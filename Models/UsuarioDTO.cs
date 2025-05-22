using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_ProyectoFinal.Models
{
    public class UsuarioDTO
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; } 
        public string Email { get; set; }
        public int RolId { get; set; }

        [ForeignKey("RolId")]
        [JsonIgnore]
        public virtual RolDTO? Rol { get; set; }

        [JsonIgnore]
        public virtual ICollection<UsuarioRolDTO> UsuarioRoles { get; } = new List<UsuarioRolDTO>();

        [JsonIgnore]
        public virtual ICollection<InscripcionDTO> Inscripciones { get; set; } = new List<InscripcionDTO>();

        [JsonIgnore]
        public virtual ICollection<CalificacionDTO> Calificaciones { get; set; } = new List<CalificacionDTO>();

        [JsonIgnore]
        public virtual ICollection<CertificadoDTO> Certificados { get; set; } = new List<CertificadoDTO>();

    }
}
