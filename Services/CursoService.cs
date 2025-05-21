using API_ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ProyectoFinal.Services
{
    public class CursoService
    {
        private readonly API_Context _Context;

        public CursoService(API_Context context)
        {
            _Context = context;
        }

        public async Task<List<CursoDTO>> getAllCursos()
        {
            try
            {
                return await _Context.Cursos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<CursoDTO> getCursoById(int id)
        {
            try
            {
                var curso = await _Context.Cursos.FindAsync(id);
                if (curso == null)
                {
                    throw new Exception($"No se encontró el curso con ID {id}");
                }
                return curso;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<CursoDTO> createCurso(CursoDTO curso)
        {
            try
            {
                var new_curso = _Context.Cursos.Add(curso);
                await _Context.SaveChangesAsync();
                return new_curso.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<CursoDTO> updateCurso(CursoDTO curso, int id)
        {
            try
            {
                var update_curso = await getCursoById(id);
                if (update_curso == null)
                {
                    throw new Exception($"No se encontró el curso con ID {id}");
                }
                _Context.Entry(update_curso).CurrentValues.SetValues(curso);
                await _Context.SaveChangesAsync();
                return update_curso;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error interno del servidor: {ex.Message}", ex);
            }
        }

        public async Task<bool> deleteCurso(int id)
        {
            try
            {
                var curso = await getCursoById(id);
                if (curso == null)
                {
                    throw new Exception($"No se encontró el curso con ID {id}");
                }
                _Context.Cursos.Remove(curso);
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
