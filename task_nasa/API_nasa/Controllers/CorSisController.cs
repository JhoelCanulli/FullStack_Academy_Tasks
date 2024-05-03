using Microsoft.AspNetCore.Mvc;
using API_nasa.Services;
using API_nasa.DTO;
using global::API_nasa.DTO;
using global::API_nasa.Services;

namespace API_nasa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorpoSistemaController : ControllerBase
    {
        private readonly CorSisService _corSisService;

        public CorpoSistemaController(CorSisService corSisService)
        {
            _corSisService = corSisService;
        }

        [HttpPost]
        public IActionResult AddRelazione([FromBody] CorSisDTO dto)
        {
            if (_corSisService.AddRelazione(dto))
            {
                return Ok();
            }
            return BadRequest("Impossibile aggiungere la relazione.");
        }

        [HttpGet]
        public IActionResult GetAllRelazioni()
        {
            var relazioni = _corSisService.GetAllRelazioni();
            return Ok(relazioni);
        }

        [HttpPut("{codiceCorpo}/{codiceSistemaPrec}/{codiceSistemaNuovo}")]
        public IActionResult UpdateRelazione(string codiceCorpo, string codiceSistemaPrec, string codiceSistemaNuovo)
        {
            if (_corSisService.UpdateRelazione(codiceCorpo, codiceSistemaPrec, codiceSistemaNuovo))
            {
                return Ok();
            }
            return BadRequest("Impossibile aggiornare la relazione.");
        }

        [HttpDelete("{codiceCorpo}/{codiceSistema}")]
        public IActionResult RemoveRelazione(string codiceCorpo, string codiceSistema)
        {
            if (_corSisService.RemoveRelazione(codiceCorpo, codiceSistema))
            {
                return Ok();
            }
            return NotFound("Relazione non trovata.");
        }
    }
}
