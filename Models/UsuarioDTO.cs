using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual RolDTO Rol { get; set; }

        public virtual ICollection<UsuarioRolDTO> UsuarioRoles { get; }
             = new List<UsuarioRolDTO>();

        public virtual ICollection<InscripcionDTO> Inscripciones { get; set; } = new List<InscripcionDTO>();

        public virtual ICollection<CalificacionDTO> Calificaciones { get; set; } = new List<CalificacionDTO>();

        public virtual ICollection<CertificadoDTO> Certificados { get; set; } = new List<CertificadoDTO>();

    }
}
