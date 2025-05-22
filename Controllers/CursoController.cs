using API_ProyectoFinal.Models;
using API_ProyectoFinal.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly CursoService _cursoService;
        public CursoController(CursoService cursoService)
        {   
            _cursoService = cursoService;

        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<CursoDTO>>> Get()
        {
            try
            {
                var cursos = await _cursoService.getAllCursos();
                if (cursos.Count == 0)
                {
                    return NotFound(new { message = "No se encontraron cursos" });
                }
                return Ok(cursos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error interno del servidor: {ex.Message}");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CursoDTO>> Get(int id )
        {
            try
            {
                var curso = await _cursoService.getCursoById(id);

                if (curso == null)
                {
                    return NotFound(new { message = "Curso no encontrado" });
                }

                return Ok(curso);
            }catch(KeyNotFoundException ex)
            {
                return BadRequest(new {message = "Id no encontrado"});
            }catch(Exception ex )
            {
                return BadRequest($"Error interno del servidor: {ex.Message}");
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<CursoDTO>> Post([FromBody] CursoDTO curso)
        {
            try
            {
                var curso_nuevo = await _cursoService.createCurso(curso);

                return Ok(curso_nuevo);

            }
            catch(Exception ex )
            {
                return BadRequest(new {message = $"Error interno del servidor: {ex.Message}"});
            }
        }
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CursoDTO>> Put(int id, [FromBody] CursoDTO curso)
        {
            try
            {
                var curso_actualizado = _cursoService.updateCurso(curso,id);
                
                return Ok(curso_actualizado);
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = $"Error interno del servidor: {ex.Message}" });
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var curso_eliminado = await _cursoService.deleteCurso(id);
                return Ok(curso_eliminado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error interno del servidor: {ex.Message}" });
            }
        }
    }
}
