using Microsoft.AspNetCore.Mvc;
using API_ProyectoFinal.Services;
using API_ProyectoFinal.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)  
        {
            _usuarioService = usuarioService;
        }
        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> Get()
        {
            try
            {
                var usuarios = await _usuarioService.getAllUsuarios();
                return Ok(usuarios);

            }
            catch(Exception ex)
            {
                return BadRequest($"Error interno del servidor: {ex.Message}");
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            try
            {
                var usuario = await _usuarioService.getUsuarioById(id);

                return Ok(usuario);
            }catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = $"No se encontró el usuario con ID {id}" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error interno: {ex.Message}" });
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> Post([FromBody] UsuarioDTO dto)
        {
            try
            {
                var creado = await _usuarioService.createUsuario(dto);

                return CreatedAtAction(
                    nameof(Get),                   
                    new { id = creado.UsuarioId },        
                    creado                         
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioDTO>> Put(int id, [FromBody] UsuarioDTO usuarioDto)
        {
            try
            {
                if (id != usuarioDto.UsuarioId)
                {
                    return BadRequest(new { message = "El ID proporcionado no coincide con el del recurso." });
                }

                var usuarioActualizado = await _usuarioService.updateUsuario(usuarioDto, id);

                if (usuarioActualizado == null)
                {
                    return NotFound(new { message = $"Usuario con ID {id} no encontrado." });
                }

                return Ok(usuarioActualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error interno del servidor: {ex.Message}" });
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuario = await _usuarioService.getUsuarioById(id);
                if (usuario == null)
                {
                    return NotFound(new { message = $"Usuario con ID {id} no encontrado." });
                }

                await _usuarioService.deleteUser(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error interno del servidor: {ex.Message}" });
            }
        }
    }
}
