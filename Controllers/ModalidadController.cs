using API_ProyectoFinal.Models;
using API_ProyectoFinal.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalidadController : ControllerBase
    {
        private readonly ModalidadService _modalidadService;

        public ModalidadController(ModalidadService modalidadService)
        {
            _modalidadService = modalidadService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<ModalidadDTO>>> Get()
        {
            try
            {
                var modalidades = await _modalidadService.getAllModalidades();

                if(modalidades.Count == 0)
                {
                    return NotFound(new {message = "No se encontraron modalidades" });
                }

                return Ok(modalidades);
            }catch(Exception ex)
            {
                return BadRequest($"Error interno del servidor: {ex.Message}");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModalidadDTO>> Get(int id)
        {
            try 
            {
                var modalidad = await _modalidadService.getModalidadById(id);
                if (modalidad == null)
                {
                    return NotFound(new { message = "Modalidad no encontrada" });
                }
                return Ok(modalidad);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = $"No se encontró la modalidad con ID {id}" });
            }catch(Exception ex)
            {
                return BadRequest($"Error interno del servidor: {ex.Message}");
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
