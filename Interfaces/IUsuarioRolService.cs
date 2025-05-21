using API_ProyectoFinal.Models;

namespace API_ProyectoFinal.Interfaces
{
    public interface IUsuarioRolService
    {
        Task<UsuarioRolDTO> createUsuarioRol(UsuarioRolDTO usuarioRol);
        Task updateUsuarioRol(int usuarioId, int nuevoRolId);

    }

}
