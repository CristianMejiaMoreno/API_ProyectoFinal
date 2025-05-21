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

        // Devuelve lista de DTOs
        public async Task<List<UsuarioRolDTO>> getAllUsuarioRol()
        {
            try
            {
                var entities = await _Context.UsuarioRoles.ToListAsync();

                // Mapeo a DTOs
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

        // Busca por UsuarioId y devuelve DTO
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

        // Crear registro desde DTO
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

        // Actualizar rol desde IDs, sin devolver nada
        public async Task updateUsuarioRol(int usuarioId, int nuevoRolId)
        {
            try
            {
                var entity = await _Context.UsuarioRoles.FirstOrDefaultAsync(ur => ur.UsuarioId == usuarioId);

                if (entity == null)
                {
                    entity = new UsuarioRolDTO
                    {
                        UsuarioId = usuarioId,
                        RolId = nuevoRolId
                    };
                    _Context.UsuarioRoles.Add(entity);
                }
                else
                {
                    entity.RolId = nuevoRolId;
                    _Context.UsuarioRoles.Update(entity);
                }

                await _Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }
    }
}
