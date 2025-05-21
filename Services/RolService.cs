using Microsoft.EntityFrameworkCore;
using API_ProyectoFinal.Models;

namespace API_ProyectoFinal.Services
{
    public class RolService
    {
        private readonly API_Context _Context;

        public RolService(API_Context context)
        {
            _Context = context;
        }

        public async Task<List<RolDTO>> getAllRoles()
        {
            try
            {
                return await _Context.Roles.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<RolDTO> getRolById(int id) 
        {
            try
            {
                var rol = await _Context.Roles.FindAsync(id); 
                if (rol == null)
                {
                    throw new Exception($"No se encontró el rol con ID {id}");
                }
                return rol;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<RolDTO> createRol(RolDTO rol)
        {
            try
            {
                var new_rol = _Context.Roles.Add(rol);

                await _Context.SaveChangesAsync();

                return new_rol.Entity;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<RolDTO> updateRol(RolDTO rol, int id)
        {
            try
            {
                var update_rol = await getRolById(id);
                if (update_rol == null)
                {
                    throw new Exception($"No se encontró el rol con ID {id}");
                }
                update_rol.NombreRol = rol.NombreRol;
                await _Context.SaveChangesAsync();
                return update_rol;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<bool> deleteRol(int id)
        {
            try
            {
                var rol = await getRolById(id);
                if (rol == null)
                {
                    throw new Exception($"No se encontró el rol con ID {id}");
                }
                _Context.Roles.Remove(rol);
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
