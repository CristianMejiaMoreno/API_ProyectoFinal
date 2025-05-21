using Microsoft.EntityFrameworkCore;
using API_ProyectoFinal.Models;
using API_ProyectoFinal.Interfaces;

namespace API_ProyectoFinal.Services
{
    public class UsuarioService
    {
        private readonly API_Context _Context;
        private readonly IUsuarioRolService _usuarioRolService;


        public UsuarioService(API_Context context, UsuarioRolService usuarioRolService)
        {
            _Context = context;
            _usuarioRolService = usuarioRolService;

        }

        public async Task<List<UsuarioDTO>> getAllUsuarios()
        {
            try
            {
                return await _Context.Usuarios.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }
        public async Task<UsuarioDTO> getUsuarioById(int id)
        {
            try
            {
                var usuario = await _Context.Usuarios.FindAsync(id);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<UsuarioDTO> createUsuario(UsuarioDTO usuario)
        {
            try
            {
                var new_usuario = _Context.Usuarios.Add(usuario);
                await _Context.SaveChangesAsync();

                if (usuario.RolId > 0)
                {
                    var usuarioRol = new UsuarioRolDTO
                    {
                        UsuarioId = new_usuario.Entity.UsuarioId,
                        RolId = usuario.RolId
                    };

                    await _usuarioRolService.createUsuarioRol(usuarioRol);
                }


                return new_usuario.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<UsuarioDTO> updateUsuario(UsuarioDTO usuario, int id)
        {
            try
            {
                var update_usuario = await getUsuarioById(id);
                if (update_usuario == null)
                {
                    throw new Exception($"No se encontró el usuario con ID {id}");
                }

                update_usuario.Nombre = usuario.Nombre;
                update_usuario.Apellido = usuario.Apellido;
                update_usuario.Email = usuario.Email;
                update_usuario.RolId = usuario.RolId;

                await _Context.SaveChangesAsync();

                await _usuarioRolService.updateUsuarioRol(id, usuario.RolId);

                return update_usuario;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }


        public async Task<bool> deleteUser(int id)
        {
            try
            {
                var usuario = await getUsuarioById(id);

                _Context.Remove(usuario);

                await _Context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }
    }
}
