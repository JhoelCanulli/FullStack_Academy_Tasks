using API_nasa.DTO;
using API_nasa.Models;
using API_nasa.Services;
using API_nasa.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API_nasa.Controllers
{
    [ApiController]
    [Route("api/sistema")]
    public class SistemaController : Controller
    {
        #region service
        readonly SistemaService service;

        public SistemaController(SistemaService service)
        {
            this.service = service;
        }
        #endregion

        #region Requests
        [HttpPost]
        public IActionResult Insert(SistemaDTO sistema)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.Insert(sistema)
            });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new Status ()
            {
                Stato = "SUCCESS",
                Data = service.GetAll()
            });
        }

        [HttpGet("{codice}")]
        public IActionResult GetByCodice(string codice)
        {
            return Ok(new Status ()
            {
                Stato = "SUCCESS",
                Data = service.GetByCodice(new SistemaDTO() { Code = codice })
            });
        }

        [HttpDelete("{codice}")]
        public IActionResult DeleteByCodice(string codice)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.DeleteByCodice(new SistemaDTO() { Code = codice })
            });
        }

        [HttpPost("update")]
        public IActionResult Update(SistemaDTO sistema)
        {
            return Ok(new Status()
            {
                Stato = "SUCCESS",
                Data = service.Update(sistema)
            });
        }
        #endregion
    }
}
