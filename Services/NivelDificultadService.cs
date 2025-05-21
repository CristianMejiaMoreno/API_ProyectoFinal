using API_ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ProyectoFinal.Services
{
    public class NivelDificultadService
    {
        public readonly API_Context _Context;
        public NivelDificultadService(API_Context context)
        {
            _Context = context;
        }
        public async Task<List<NivelDificultadDTO>> getAllNivelesDificultad()
        {
            try
            {
                return await _Context.NivelDificultad.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<NivelDificultadDTO> getNivelDificultadById(int id)
        {
            try
            {
                var nivelDificultad = await _Context.NivelDificultad.FindAsync(id);
                if (nivelDificultad == null)
                {
                    throw new Exception($"No se encontró el nivel de dificultad con ID {id}");
                }
                return nivelDificultad;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<NivelDificultadDTO> createNivelDificultad(NivelDificultadDTO nivelDificultad)
        {
            try
            {
                var new_nivelDificultad = _Context.NivelDificultad.Add(nivelDificultad);
                await _Context.SaveChangesAsync();
                return new_nivelDificultad.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<NivelDificultadDTO> updateNivelDificultad(NivelDificultadDTO nivelDificultad, int id)
        {
            try
            {
                var update_nivelDificultad = await getNivelDificultadById(id);
                if (update_nivelDificultad == null)
                {
                    throw new Exception($"No se encontró el nivel de dificultad con ID {id}");
                }
                _Context.Entry(update_nivelDificultad).CurrentValues.SetValues(nivelDificultad);
                await _Context.SaveChangesAsync();
                return update_nivelDificultad;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<bool> deleteNivelDificultad(int id)
        {
            try
            {
                var nivelDificultad = await getNivelDificultadById(id);
                if (nivelDificultad == null)
                {
                    throw new Exception($"No se encontró el nivel de dificultad con ID {id}");
                }
                _Context.NivelDificultad.Remove(nivelDificultad);
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
