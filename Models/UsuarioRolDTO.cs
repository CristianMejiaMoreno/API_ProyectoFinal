namespace API_ProyectoFinal.Models
{
    public class UsuarioRolDTO
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }

        public virtual UsuarioDTO Usuario { get; set; }
        public virtual RolDTO Rol { get; set; }
    }
}
