using API_ProyectoFinal.Models;
using API_ProyectoFinal.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {

        private readonly CiudadService _ciudadService;

        public CiudadController(CiudadService ciudadService)
        {
            _ciudadService = ciudadService;
        }

        // GET: api/<CiudadController>
        [HttpGet]
        public async Task<ActionResult<List<CiudadDTO>>> Get()
        {
            try
            {
                var ciudadades = await _ciudadService.getAllCiudades();

                return Ok(ciudadades);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error interno del servidor: {ex.Message}");
            }
        }


        // GET api/<CiudadController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CiudadDTO>> Get(int id)
        {
            try
            {
                var ciudad = await _ciudadService.getCiudadById(id);
                return Ok(ciudad);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error interno del servidor: {ex.Message}");
            }
        }

        // POST api/<CiudadController>
        [HttpPost]
        public async Task<ActionResult<CiudadDTO>> Post([FromBody] CiudadDTO dto)
        {
            try
            {
                var creado = await _ciudadService.createCiudad(dto);
                return CreatedAtAction(nameof(Get), new { id = creado.CiudadId }, creado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<CiudadController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CiudadDTO>> Put(int id, [FromBody] CiudadDTO dto)
        {
            try
            {
                var actualizado = await _ciudadService.updateCiudad(id, dto);
                return Ok(actualizado);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE api/<CiudadController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var eliminado = await _ciudadService.deleteCiudad(id);
                if (eliminado)
                {
                    return Ok(new { message = "Ciudad eliminada correctamente" });
                }
                else
                {
                    return NotFound(new { message = "Ciudad no encontrada" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
