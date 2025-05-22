using API_ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ProyectoFinal.Services
{
    public class ModalidadService
    {
        private readonly API_Context _Context;

        public ModalidadService(API_Context context)
        {
            _Context = context;
        }

        public async Task<List<ModalidadDTO>> getAllModalidades()
        {
            try
            {
                return await _Context.Modalidades.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<ModalidadDTO> getModalidadById(int id)
        {
            try
            {
                var modalidad = await _Context.Modalidades.FindAsync(id);
                if (modalidad == null)
                {
                    throw new Exception($"No se encontró la modalidad con ID {id}");
                }
                return modalidad;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<ModalidadDTO> createModalidad(ModalidadDTO modalidad)
        {
            try
            {
                var new_modalidad = _Context.Modalidades.Add(modalidad);
                await _Context.SaveChangesAsync();
                return new_modalidad.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<ModalidadDTO> updateModalidad(ModalidadDTO modalidad, int id)
        {
            try
            {
                var update_modalidad = await getModalidadById(id);
                if (update_modalidad == null)
                {
                    throw new Exception($"No se encontró la modalidad con ID {id}");
                }
                _Context.Entry(update_modalidad).CurrentValues.SetValues(modalidad);
                await _Context.SaveChangesAsync();
                return update_modalidad;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }
        public async Task<bool> deleteModalidad(int id)
        {
            try
            {
                var modalidad = await getModalidadById(id);
                if (modalidad == null)
                {
                    throw new Exception($"No se encontró la modalidad con ID {id}");
                }
                _Context.Modalidades.Remove(modalidad);
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
