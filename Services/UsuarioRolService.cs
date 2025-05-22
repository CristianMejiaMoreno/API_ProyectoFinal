using API_ProyectoFinal.Interfaces;
using API_ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ProyectoFinal.Services
{
    public class UsuarioRolService : IUsuarioRolService
    {
        private readonly API_Context _Context;
        public UsuarioRolService(API_Context context)
        {
            _Context = context;
        }

        public async Task<List<UsuarioRolDTO>> getAllUsuarioRol()
        {
            try
            {
                var entities = await _Context.UsuarioRoles.ToListAsync();

                var dtos = entities.Select(e => new UsuarioRolDTO
                {
                    UsuarioId = e.UsuarioId,
                    RolId = e.RolId
                }).ToList();

                return dtos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<UsuarioRolDTO> getUsuarioRolByUsuarioId(int usuarioId)
        {
            try
            {
                var entity = await _Context.UsuarioRoles
                    .FirstOrDefaultAsync(ur => ur.UsuarioId == usuarioId);

                if (entity == null)
                    throw new Exception($"No se encontró el usuarioRol para el usuario con ID {usuarioId}");

                return new UsuarioRolDTO
                {
                    UsuarioId = entity.UsuarioId,
                    RolId = entity.RolId
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<UsuarioRolDTO> createUsuarioRol(UsuarioRolDTO usuarioRolDTO)
        {
            try
            {
                var entity = new UsuarioRolDTO
                {
                    UsuarioId = usuarioRolDTO.UsuarioId,
                    RolId = usuarioRolDTO.RolId
                };

                var newEntity = _Context.UsuarioRoles.Add(entity);
                await _Context.SaveChangesAsync();

                return new UsuarioRolDTO
                {
                    UsuarioId = newEntity.Entity.UsuarioId,
                    RolId = newEntity.Entity.RolId
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task updateUsuarioRol(int usuarioId, int nuevoRolId)
        {
            try
            {
                var entity = await _Context.UsuarioRoles.FirstOrDefaultAsync(ur => ur.UsuarioId == usuarioId);

                if (entity != null)
                {
                    _Context.UsuarioRoles.Remove(entity);
                    await _Context.SaveChangesAsync();
                }

                var nuevoUsuarioRol = new UsuarioRolDTO
                {
                    UsuarioId = usuarioId,
                    RolId = nuevoRolId
                };
                _Context.UsuarioRoles.Add(nuevoUsuarioRol);
                await _Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<bool> deleteUsuarioRol(int usuarioId)
        {
            try
            {
                var entity = await _Context.UsuarioRoles.FirstOrDefaultAsync(ur => ur.UsuarioId == usuarioId);
                if (entity == null)
                    throw new Exception($"No se encontró el usuarioRol para el usuario con ID {usuarioId}");

                _Context.UsuarioRoles.Remove(entity);
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
