using API_ProyectoFinal.Models;
using API_ProyectoFinal.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RolService _rolService;
        public RolController(RolService rolService)
        {
            _rolService = rolService;
        }

        // GET: api/<RolController>
        [HttpGet]
        public async Task<ActionResult<List<RolDTO>>> Get()
        {
            try
            {
                var roles = await _rolService.getAllRoles();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error interno: {ex.Message}" });
            }
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolDTO>> Get(int id)
        {
            try
            {
                var rol = await _rolService.getRolById(id);

                if (rol == null)
                {
                    return NotFound(new { message = "Rol no encontrado" });
                }

                return Ok(rol);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error interno: {ex.Message}" });
            }
        }

        // POST api/<RolController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolDTO rolDto)
        {
            try
            {
                if (rolDto == null)
                {
                    return BadRequest(new { message = "El rol enviado es nulo" });
                }

                await _rolService.createRol(rolDto);

                return CreatedAtAction(nameof(Get), new { id = rolDto.RolId }, rolDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error al crear el rol: {ex.Message}" });
            }
        }

        // PUT api/<RolController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RolDTO rolDto)
        {
            try
            {
                if (rolDto == null || id != rolDto.RolId)
                {
                    return BadRequest(new { message = "Datos inválidos para actualizar el rol" });
                }

                var existingRol = await _rolService.getRolById(id);
                if (existingRol == null)
                {
                    return NotFound(new { message = "Rol no encontrado" });
                }

                await _rolService.updateRol(rolDto, id);

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error al actualizar el rol: {ex.Message}" });
            }
        }


        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var existingRol = await _rolService.getRolById(id);
                if (existingRol == null)
                {
                    return NotFound(new { message = "Rol no encontrado" });
                }

                await _rolService.deleteRol(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error al eliminar el rol: {ex.Message}" });
            }
        }
    }
}
