using Microsoft.EntityFrameworkCore;
using API_ProyectoFinal.Models;

namespace API_ProyectoFinal.Services
{
    public class CiudadService
    {
        private readonly API_Context _Context;

        public CiudadService(API_Context context)
        {
            _Context = context;
        }

        public async Task<List<CiudadDTO>> getAllCiudades()
        {
            try
            {
                return await _Context.Ciudad.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<CiudadDTO> getCiudadById(int id)
        {
            try
            {
                var ciudad = await _Context.Ciudad.FindAsync(id);

                if (ciudad == null)
                {
                    throw new Exception($"No se encontró la ciudad con ID {id}");
                }

                return ciudad;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}");
            }
        }

        public async Task<CiudadDTO> createCiudad(CiudadDTO ciudad)
        {
            try
            {
                var new_ciudad = _Context.Ciudad.Add(ciudad);
                await _Context.SaveChangesAsync();
                return new_ciudad.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<CiudadDTO> updateCiudad(int id, CiudadDTO ciudad)
        {
            try
            {
                var ciudadToUpdate = await getCiudadById(id);
                if (ciudadToUpdate == null)
                {
                    throw new Exception($"No se encontró la ciudad con ID {id}");
                }
                ciudadToUpdate.Nombre = ciudad.Nombre;
                ciudadToUpdate.ProvinciaEstado = ciudad.ProvinciaEstado;
                ciudadToUpdate.Pais = ciudad.Pais;
                ciudadToUpdate.CodigoPostal = ciudad.CodigoPostal;
                _Context.Ciudad.Update(ciudadToUpdate);
                await _Context.SaveChangesAsync();
                return ciudadToUpdate;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<bool> deleteCiudad(int id)
        {
            try
            {
                var ciudadToDelete = await getCiudadById(id);
                if (ciudadToDelete == null)
                {
                    throw new Exception($"No se encontró la ciudad con ID {id}");
                }
                _Context.Ciudad.Remove(ciudadToDelete);
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
